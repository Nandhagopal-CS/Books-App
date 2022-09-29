using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }

        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int CouponId { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

        public Order()
        {

        }
        public Order(int orderId,string userName,int bookId,int quantity,int couponId,string location,string status)
        {
            OrderId = orderId;
            UserName = userName;
            BookId=bookId;
            Quantity=quantity;
            CouponId=couponId;
            Location=location;
            Status=status;
        }
    }
}