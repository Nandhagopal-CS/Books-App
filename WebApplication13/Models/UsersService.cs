using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication13.Models
{
    public class UsersService : IUsers
    {
        SqlConnection conn;
        SqlCommand comm;

        public UsersService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Users AddUsers(Users users)
        {
            comm.CommandText = "insert into Users values('" + users.UserName + "','" +users.Password + "','" + users.Mobile + "','" +users.Status + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return users;
            }
            else
            {
                return null;
            }
        }

        public void DeleteUsers(string userName)
        {
            comm.CommandText = "Delete from Users where UserName='" + userName+"'";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Users> GetAllUsers()
        {
            List<Users> list = new List<Users>();
            comm.CommandText = "select * from Users";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                string u_name = reader["UserName"].ToString();
                string p = reader["PassWord"].ToString();
                string mobile = reader["Mobile"].ToString();
                string status = reader["Status"].ToString();
                
                list.Add(new Users( u_name, p,mobile, status));
            }
            conn.Close();
            return list;
        }

       

        public Users GetUserBYUserName(string userName)
        {
            comm.CommandText = "select * from Users where UserName='" +userName + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();


            while (reader.Read())
            {
                
                string u_name = reader["UserName"].ToString();
                string pass = reader["Password"].ToString();
                string mob = reader["Mobile"].ToString();
                string status = reader["Status"].ToString();
                

                Users b = new Users(u_name,pass,mob,status);
                conn.Close();

                return b;
            }
            return null;
        }

        public void UpdateUsers(Users users)
        {
            comm.CommandText = "update Users set Password='" + users.Password + "',Mobile='" + users.Mobile + "', Status='" + users.Status + "' where UserName='" + users.UserName+"'";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}