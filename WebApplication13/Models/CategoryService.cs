using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication13.Models
{
    public class CategoryService : ICategory
    {
        SqlConnection conn;
        SqlCommand comm;
        public CategoryService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Category AddCategory(Category category)
        {
            comm.CommandText = "insert into Category values(" + category.CategoryId + ",'" + category.CategoryName + "','" + category.Description + "','" + category.Image + "','" + category.Status + "'," + category.Position + ",'" + category.CreatedAt + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public void DeleteCategory(int categoryId)
        {
            comm.CommandText = "Delete from Category where CategoryId=" + categoryId ;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Category> GetAllCategory()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from Category";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                int c_id = Convert.ToInt32(reader["CategoryId"]);
                string c_name = reader["CategoryName"].ToString();
                string d = reader["Description"].ToString();
                string image = reader["Image"].ToString();
                string status = reader["Status"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string c_at = reader["CreatedAt"].ToString();
                list.Add(new Category(c_id, c_name, d, image, status, pos, c_at));
            }
            conn.Close();
            return list;
        }
    
        public void UpdateCategory(Category cat)
            {
            comm.CommandText = "update Category set CategoryName='" + cat.CategoryName + "',Description='" + cat.Description + "',Image='" + cat.Image + "',Status='" + cat.Status + "', Position=" + cat.Position + " where CategoryId=" + cat.CategoryId;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        }
    }