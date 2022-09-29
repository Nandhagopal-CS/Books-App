using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class Cart
    {
        public string UserName { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public Cart()
        {

        }
        public Cart(string userName,int bookId,int quantity)
        {
            UserName = userName;
            BookId = bookId;
            Quantity = quantity;
        }
    }
}