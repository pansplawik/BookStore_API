using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAPI.Models.Info
{
    public class AuthorInfo
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public AuthorInfo()
        {

        }

        public AuthorInfo(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public AuthorInfo(Author author)
        {
            AuthorId = author.AuthorId;
            FirstName = author.FirstName;
            Surname = author.Surname;
        }
    }
}