using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksAPI.Controllers
{
    public class GenresController : ApiController
    {
        [HttpGet]
        public List<string> GetGenres()
        {
            List<string> values = new List<string>();
            foreach (var itemType in Enum.GetValues(typeof(Genre)))
            {
                //For each value of this enumeration, add a new EnumValue instance
                values.Add(Enum.GetName(typeof(Genre), itemType));
            }
            return values;
        }
    }
}
