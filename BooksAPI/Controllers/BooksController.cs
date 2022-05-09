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
    public class BooksController : ApiController
    {
        readonly BooksManager _booksManager; 
        public BooksController()
        {
            _booksManager = new BooksManager();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var books = _booksManager.GetAllBooks();
            return Ok(books);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var book = _booksManager.GetBook(id);
            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        [HttpGet]
        public IHttpActionResult Get(Genre genre)
        {
            var books = _booksManager.GetBooks(genre);
            if (books.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Ok(books);
        }
        [HttpGet]
        public IHttpActionResult Get(string author)
        {
            var booksAuthor = _booksManager.GetAuthor(author);
            var books = _booksManager.GetAuthorBooks(booksAuthor);

            return Ok(books);
        }

        [HttpPost]
        [ResponseType(typeof(BookInfo))]
        public IHttpActionResult Post([FromBody] Book book)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool success = _booksManager.AddBook(book);
   
            if (success)
            {
                BookInfo bookInfo = new BookInfo(book);
                return CreatedAtRoute("DefaultApi", new { id = book.BookId }, bookInfo);
            }
            else
            {
                return Conflict();
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid");

            if (id != book.BookId)
            {
                return BadRequest();
            }

            bool success = _booksManager.EditBook(book);
            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid book id");

            bool success = _booksManager.RemoveBook(id);
            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
