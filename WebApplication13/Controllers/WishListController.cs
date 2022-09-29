using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class WishListController : ApiController
    {

        IWishList WishlistRep;
        public WishListController()
        {
            WishlistRep = new WishListService();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = WishlistRep.ViewWishList();
            return Ok(data);
        }



        [HttpPost]
        public IHttpActionResult Post(WishList wishlist)
        {
            var data = WishlistRep.AddtoWishList(wishlist);
            return Ok(data);



        }
        [HttpDelete]
        public IHttpActionResult Delete(string uname, int bid)
        {
            WishlistRep.DeletefromWishList(uname, bid);
            return Ok();
        }
    }
}
