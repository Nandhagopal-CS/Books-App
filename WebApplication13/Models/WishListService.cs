using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication13.Models
{
    public class WishListService : IWishList
    {
        SqlConnection conn;
        SqlCommand comm;
        public WishListService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public WishList AddtoWishList(WishList WishList)
        {
            comm.CommandText = "insert into WishList values('" + WishList.UserName + "'," + WishList.BookId + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            if (row > 0)
            {



                return WishList;
            }
            return null;
        }



        public void DeletefromWishList(string uname, int bid)
        {
            comm.CommandText = "Delete from WishList where Username='" + uname + "' and BookId=" + bid;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
        }

        public List<WishList> ViewWishList()
        {
            List<WishList> list = new List<WishList>();
            comm.CommandText = "select * from WishList";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {




                string username = reader["Username"].ToString();
                int bid = Convert.ToInt32(reader["BookId"]);

                list.Add(new WishList(username, bid));
            }
            conn.Close();
            return list;
        }
    }
}