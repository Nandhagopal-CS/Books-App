using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class BookController : ApiController
    {
        private IBook repository;

        public BookController()
        {
            repository = new BookService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllBook();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(string author)
        {
            var data = repository.GetByAuthor(author);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int isbn)
        {
            var data = repository.GetByISBN(isbn);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get2(string catName)
        {
            var data = repository.GetByCategory(catName);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get3(string name)
        {
            var data = repository.GetByName(name);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            var data = repository.AddBook(book);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteBook(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(Book book)
        {
            repository.UpdateBook(book);
            return Ok(book);
        }


    }
}
