using BooksAPI.Models.Info;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Genre Genre { get; set; }
        [Required]
        public virtual Author Author { get; set; }

        public Book()
        {

        }

        public Book(string title, Genre genre, Author author)
        {
            Title = title;
            Genre = genre;
            Author = author;
        }

        public Book(BookInfo bookInfo)
        {
            Title = bookInfo.Title;
            Genre = bookInfo.Genre;
            Author = new Author(bookInfo.Author);
        }

    }
}