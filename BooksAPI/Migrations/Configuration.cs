namespace BooksAPI.Migrations
{
    using BooksAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BooksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BooksContext context)
        {
            // Crime
            Author author = new Author("Stieg", "Larson");
            Book book = new Book("The Girl with the Dragon Tattoo", Genre.Crime, author);
            context.Authors.Add(author);
            context.Books.Add(book);
            book = new Book("The Girl Who Played with Fire", Genre.Crime, author);
            context.Books.Add(book);
            book = new Book("The Girl Who Kicked the Hornet's Nest", Genre.Crime, author);

            author = new Author("Paula", "Hawkins");
            book = new Book("The Girl on the Train", Genre.Crime, author);
            context.Authors.Add(author);
            context.Books.Add(book);

            author = new Author("Mario", "Puzo");
            book = new Book("The Godfather", Genre.Crime, author);
            context.Authors.Add(author);
            context.Books.Add(book);

            // Fantasy
            author = new Author("J.R.R.", "Tolkien");
            context.Authors.Add(author);
            book = new Book("The Hobbit, or There and Back Again", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("The Fellowship of the Ring", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("The Two Towers", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("The Return of the King", Genre.Fantasy, author);
            context.Books.Add(book);

            author = new Author("Brandon", "Sanderson");
            context.Authors.Add(author);
            book = new Book("The Way of Kings", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("Words of Radiance", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("Oathbringer", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("Rhythm of War", Genre.Fantasy, author);
            context.Books.Add(book);

            author = new Author("Ursula", "Le Guin");
            context.Authors.Add(author);
            book = new Book("A Wizard of Earthsea", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("The Tombs of Atuan", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("The Farthest Shore", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("Tehanu", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("Tales from Earthsea", Genre.Fantasy, author);
            context.Books.Add(book);
            book = new Book("The Other Wind", Genre.Fantasy, author);
            context.Books.Add(book);

            context.SaveChanges();
        }
    }
}
