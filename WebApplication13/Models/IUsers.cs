using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public interface IUsers
    {
        List<Users> GetAllUsers();
        Users AddUsers(Users users);

        void UpdateUsers(Users users);

        void DeleteUsers(string userName);
        Users GetUserBYUserName(string userName);
    }
}
