using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public interface ICategory
    {
        List<Category> GetAllCategory();
        Category AddCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category cat);
    }
}

