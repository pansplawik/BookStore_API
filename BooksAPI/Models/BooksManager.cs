using BooksAPI.Models.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.Models
{
    public class BooksManager
    {
        public List<BookInfo> GetAllBooks()
        {
            List<BookInfo> result;
            using (var context = new BooksContext())
            {
                result = context.Books.ToList()
                                      .Select(x => new BookInfo(x))
                                      .ToList();
            }   
            return result;
        }
        public BookInfo GetBook(int id)
        {
            BookInfo result = null;
            using (var context = new BooksContext())
            {
                Book book = context.Books.FirstOrDefault(x => x.BookId == id);
                if (book != null)
                {
                    result = new BookInfo(book);
                }
            }
            return result;
        }
        public List<BookInfo> GetBooks(Genre genre)
        {
            List<BookInfo> result;
            using (var context = new BooksContext())
            {
                result = context.Books.Where(x => x.Genre == genre)
                                      .ToList()
                                      .Select(x => new BookInfo(x))
                                      .ToList();
            }

            return result;
        }

        internal void AddAuthor(Author author, object a)
        {
            throw new NotImplementedException();
        }

        public List<AuthorInfo> GetAllAuthors()
        {
            List<AuthorInfo> result;
            using (var context = new BooksContext())
            {
                result = context.Authors.ToList()
                                        .Select(x => new AuthorInfo(x))
                                        .ToList();
            }
            return result;
        }
        public AuthorInfo GetAuthor(int id)
        {
            AuthorInfo result = null;
            using (var context = new BooksContext())
            {
                Author book = context.Authors.FirstOrDefault(x => x.AuthorId == id);
                if (book != null)
                {
                    result = new AuthorInfo(book);
                }
            }
            return result;
        }
        public AuthorInfo GetAuthor(string surname)
        {
            AuthorInfo result = null;
            using (var context = new BooksContext())
            {
                Author author = context.Authors.FirstOrDefault(x => x.Surname.ToLower() == surname.ToLower());
                if(author != null)
                {
                    result = new AuthorInfo(author);
                }
            }
            return result;
        }
  
        public List<BookInfo> GetAuthorBooks(AuthorInfo author)
        {
            List<BookInfo> result;
            using (var context = new BooksContext())
            {
                result = context.Books.Where(x => x.Author.AuthorId == author.AuthorId)
                                      .ToList()
                                      .Select(x => new BookInfo(x))
                                      .ToList();
            }
            return result;
        }

        private bool CheckIfBookExists(Book book)
        {
            Book DBbook = null;
            using (var context = new BooksContext())
            {
                DBbook = context.Books.FirstOrDefault(x => x.Title == book.Title);
                if (DBbook == null)
                {
                    return false;
                }
            }
            return true;
        }
        public bool AddBook(Book book)
        {
            if (!CheckIfBookExists(book))
            {
                using (var context = new BooksContext())
                {
                    Author author = context.Authors.FirstOrDefault(x => x.FirstName == book.Author.FirstName &&
                                                           x.Surname == book.Author.Surname);
                    if (author == null)
                    {
                        AddAuthor(book.Author);
						book.Author = context.Authors.FirstOrDefault(x => x.FirstName == book.Author.FirstName &&
                                                           x.Surname == book.Author.Surname);
                    }
                    else
                    {
                        book.Author = author;
                    }

                    context.Books.Add(book);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool AddAuthor(Author author)
        {
            using (var context = new BooksContext())
            {
                Author dbAuthor = context.Authors.FirstOrDefault(x => x.FirstName == author.FirstName &&
                                       x.Surname == author.Surname);
                if(dbAuthor != null)
                {
                    return false;
                }

                context.Authors.Add(author);
                context.SaveChanges();
                return true;
            };
        }

        public bool EditBook(Book book)
        {
            using (var context = new BooksContext())
            {
                Book dbBook = context.Books.FirstOrDefault(x => x.BookId == book.BookId);
                Author dbAuthor = context.Authors.FirstOrDefault(x => x.AuthorId == book.Author.AuthorId);

                if(dbBook == null)
                {
                    return false;
                }
                if (dbAuthor == null)
                {
                    return false;
                }

                dbBook.Title = book.Title;
                dbBook.Genre = book.Genre;
                dbBook.Author = dbAuthor;

                context.SaveChanges();
                return true;
            }
        }
        public bool EditAuthor(Author author)
        {
            using (var context = new BooksContext())
            {
                Author dbAuthor = context.Authors.FirstOrDefault(x => x.AuthorId == author.AuthorId);

                if (dbAuthor == null)
                {
                    return false;
                }

                dbAuthor.FirstName = author.FirstName;
                dbAuthor.Surname = author.Surname;

                context.SaveChanges();
                return true;
            }
        }

        public bool RemoveBook(int id)
        {
            using (var context = new BooksContext())
            {
                Book book = context.Books.FirstOrDefault(x => x.BookId == id);
                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public bool RemoveAuthor(int id)
        {
            using (var context = new BooksContext())
            {
                Author author = context.Authors.FirstOrDefault(x => x.AuthorId == id);

                if (author != null )
                {
                    context.Authors.Remove(author);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}