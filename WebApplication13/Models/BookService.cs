using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication13.Models
{
    public class BookService : IBook
    {
        SqlConnection conn;
        SqlCommand comm;
        public BookService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Book AddBook(Book book)
        {
            comm.CommandText = "insert into Books values(" + book.BookId + "," + book.CategoryId + ",'" + book.Title + "','" + book.Author + "'," + book.ISBN + "," + book.Year + "," + book.Price + ",'" + book.Description + "'," + book.Position + ",'" + book.Status + "','" + book.Image + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public void DeleteBook(int bookId)
        {
            comm.CommandText = "Delete from Books where BookId=" + bookId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Book> GetAllBook()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Books";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                int b_id = Convert.ToInt32(reader["BookId"]);
                int c_id = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int iSBN = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string d = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string status = reader["Status"].ToString();
                string image = reader["Image"].ToString();
                
                list.Add(new Book(b_id,c_id,title,author,iSBN,year,price,d,pos,status,image));
            }
            conn.Close();
            return list;
        }

        public void UpdateBook(Book book)
        {
            comm.CommandText = "update Books set Title='" + book.Title + "',Author='" + book.Author + "',ISBN=" + book.ISBN + ",Year=" + book.Year + ",Price=" + book.Price + ",Description='" + book.Description + "', Position=" + book.Position + ",Status='" + book.Status + "',Image='" + book.Image + "' where BookId=" + book.BookId;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        List<Book> IBook.GetByAuthor(string authors)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Books where Author='"+authors+"'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                int b_id = Convert.ToInt32(reader["BookId"]);
                int c_id = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int iSBN = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string d = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string status = reader["Status"].ToString();
                string image = reader["Image"].ToString();

                list.Add(new Book(b_id, c_id, title, author, iSBN, year, price, d, pos, status, image));
            }
            conn.Close();
            return list;
        }

       

        List<Book> IBook.GetByCategory(string category)
        {
            throw new NotImplementedException();
        }


        Book IBook.GetByISBN(int isBN)
        {
            comm.CommandText = "select * from Books where ISBN='" + isBN + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            

            while (reader.Read())
            {
                int b_id = Convert.ToInt32(reader["BookId"]);
                int c_id = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int iSBN = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string d = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string status = reader["Status"].ToString();
                string image = reader["Image"].ToString();

                 Book b =new Book(b_id, c_id, title, author, iSBN, year, price, d, pos, status, image);
                conn.Close();

                return b;
            }
            return null;
           
        }

     

        List<Book> IBook.GetByName(string name)
        {
            
        }
    }
}