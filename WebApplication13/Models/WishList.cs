using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class WishList
    {
        public string UserName { get; set; }
        public int BookId { get; set; }


        public WishList()
        {

        }

        public WishList(string userName,int bookId)
        {
            UserName = userName;
            BookId = bookId;

        }
    }
}
    