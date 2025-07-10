using ManagerTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTasks.Models
{
    public class Admin : User
    {
        public Admin(string uname, string userpassword, string role) : base(uname, userpassword, role)
        {
            aUserName = uname;
            aUserPassword = userpassword;
            aRole = role;
        }

        public string aUserName { get; set; }
        public string aUserPassword { get; set; }
        public string aRole { get; set; }
    }
}
