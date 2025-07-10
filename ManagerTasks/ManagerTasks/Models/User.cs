using ManagerTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTasks.Models
{
    public class User : IUser
    {
        public User() { }
        public User(string uname, string userpassword)
        {
            UserName = uname;
            UserPassword = userpassword;
        }
        public User(string uname, string userpassword, string role)
        {
            UserName = uname;
            UserPassword = userpassword;
            Role = role;
        }

        public string UserName {  get; set; }
        public string UserPassword {  get; set; }
        public string Role {  get; set; }

        public List<TaskItem> taskItems = new List<TaskItem>
        {
            new TaskItem(1, "test0", "test0", new DateTime(2025, 12, 24), "закрыта")
        };
        public static List<User> users = new List<User>
        {
            new User("test", "test1", "client"),
            new User("test0", "test0", "admin"),
            new User("t", "t", "admin")
        };
    }
}
