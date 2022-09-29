using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class UsersController : ApiController
    {
        private IUsers repository;

        public UsersController()
        {
            repository = new UsersService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllUsers();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Users user)
        {
            var data = repository.AddUsers(user);
            return Ok(data);

        }

        [HttpPut]
        public IHttpActionResult put(Users user)
        {
            repository.UpdateUsers(user);
            return Ok(user);
        }
        [HttpDelete]
        public IHttpActionResult Delete(string username)
        {
            repository.DeleteUsers(username);
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get1(string u_n)
        {
            var data = repository.GetUserBYUserName(u_n);
            return Ok(data);
        }
    }
}
