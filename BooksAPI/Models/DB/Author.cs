using BooksAPI.Models.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }

        public Author()
        {

        }

        public Author(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public Author(AuthorInfo authorInfo)
        {
            FirstName = authorInfo.FirstName;
            Surname = authorInfo.Surname;
        }
    }
}