using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Status { get; set; }

        public Users()
        {

        }
        
        public Users(string userName,string password,string mobile,string status)
        {
            UserName = userName;
            Password = password;
            Mobile = mobile;
            Status = status;
        }
    }

    
}