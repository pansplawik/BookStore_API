using BooksAPI.Models;
using BooksAPI.Models.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BooksAPI.Controllers
{
    public class AuthorsController : ApiController
    {
        readonly Author Author;
        readonly BooksManager _booksManager;

        public AuthorsController()
        {
            _booksManager = new BooksManager();
        }

        ////////// DO UZUPEŁNIENIA ////////// 
        // GET /authors
        public IHttpActionResult Get()
        {
            var books = _booksManager.GetAllAuthors();
            return Ok(books);
        }

        // GET /authors/1

        public IHttpActionResult Get(int id)
        {
            if (_booksManager.GetAuthor(id)==null)
            {
                return NotFound();
            }
            var book = _booksManager.GetAuthor(id);
            return Ok(book);
        }
        // POST /authors

        public IHttpActionResult Post(Author author)
        {
            var book = _booksManager.AddAuthor(author);
            return Ok();
        }


        // PUT /authors

        public IHttpActionResult Put(Author author)
        {

            var book=_booksManager.EditAuthor(author);
            return Ok(book);
        }

        // DELETE /authors/1

        public IHttpActionResult Delete(int id)
        {
            if (_booksManager.GetAuthor(id)==null)
            {
                return NotFound();
            }
            _booksManager.RemoveAuthor(id);
            return Ok();
        }

        /////////////////////////////////////
    }
}
