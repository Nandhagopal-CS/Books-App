using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication13.Models
{
    public class OrderService:IOrder
    {
        SqlConnection conn;
        SqlCommand comm;
        public OrderService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Order AddOrder(Order order)
        {
            comm.CommandText = "insert into Orders values(" + order.OrderId + ",'" + order.UserName + "'," + order.BookId + "," + order.Quantity + "," + order.CouponId + ",'" + order.Location + "','" + order.Status + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return order;
            }
            else
            {
                return null;
            }
        }

        List<Order> IOrder.GetAllOrder()
        {
            List<Order> list = new List<Order>();
            comm.CommandText = "select * from Orders";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                int o_id = Convert.ToInt32(reader["OrderId"]);
                string u_name = reader["UserName"].ToString();
                int b_id = Convert.ToInt32(reader["BookId"]);
                int quantity = Convert.ToInt32(reader["Quantity"]);
                int c_id = Convert.ToInt32(reader["CouponId"]);
                string Location = reader["Location"].ToString();
                string status = reader["Status"].ToString();
                

                list.Add(new Order(o_id,u_name,b_id,quantity,c_id, Location, status));
            }
            conn.Close();
            return list;
        }

        int IOrder.GetOrderPrice(Order order)
        {
            int tprice = 0;
            comm.CommandText = "select Books.Price,Orders.Quantity from Books join Orders on Books.BookId=Orders.OrderId where Orders.OrderId=" + order.OrderId;

            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                int price = Convert.ToInt32(reader["Price"]);
                int qty = Convert.ToInt32(reader["Quantity"]);
                tprice = price * qty;
            }
            conn.Close();
            comm.CommandText = "select Discount from Coupon where CouponId=" + order.CouponId;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader1 = comm.ExecuteReader();
            while (reader1.Read())
            {
                int discount = Convert.ToInt32(reader1["Discount"]);
                tprice = tprice - discount;
            }
            conn.Close();
            return tprice;
        }

        void IOrder.StatusOrder(int orderId, string status)
        {
            comm.CommandText = "update Orders set  Status ='" + status + "' where OrderId=" + orderId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}