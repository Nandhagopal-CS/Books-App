using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class OrderController : ApiController
    {
        private IOrder repository;

        public OrderController()
        {
            repository = new OrderService();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllOrder();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Order order)
        {
            var data = repository.AddOrder(order);
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult put(Order order)
        {
            var data = repository.GetOrderPrice(order);
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult put(int orderId, string status)
        {
            repository.StatusOrder(orderId,status);
            return Ok();
        }


    }
}
