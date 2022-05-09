using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.Models.Info
{
    public class BookInfo
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Genre Genre { get; set; }
        public AuthorInfo Author { get; set; }

        public BookInfo()
        {

        }

        public BookInfo(string title, Genre genre, AuthorInfo author)
        {
            Title = title;
            Genre = genre;
            Author = author;
        }

        public BookInfo(Book book)
        {
            BookId = book.BookId;
            Title = book.Title;
            Genre = book.Genre;
            Author = new AuthorInfo(book.Author);
        }
    }
}