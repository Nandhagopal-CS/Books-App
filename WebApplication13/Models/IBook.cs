using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public interface IBook
    {
        List<Book> GetAllBook();
        Book AddBook(Book book);
        List<Book> GetByName(string name);
        List<Book> GetByCategory(string category);
        Book GetByISBN(int iSBN);

        List<Book> GetByAuthor(string author);

        void DeleteBook(int bookId);
        void UpdateBook(Book book);
    }
}
