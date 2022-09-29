using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public interface IWishList
    {

        WishList AddtoWishList(WishList wishlist);
        void DeletefromWishList(string uname, int bid);
        List<WishList> ViewWishList();
    }
}
