using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategory repository;

        public CategoryController()
        {
            repository = new CategoryService();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategory();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            var data = repository.AddCategory(category);
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteCategory(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(Category cat)
        {
            repository.UpdateCategory(cat);
            return Ok();
        }
    }
}
