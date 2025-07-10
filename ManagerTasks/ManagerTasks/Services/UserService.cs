using ManagerTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTasks.Services
{
    public class UserService : User
    {
        public void ViewUsers()
        {
            foreach (var usr in users)
            {
                Console.WriteLine();
                Console.WriteLine($"Имя пользователя: {usr.UserName}\nПароль пользователя: {usr.UserPassword}\nРоль: {usr.Role}");
                Console.WriteLine();
            }
        }
        public void Login(string login, string password, out bool isjoin, out bool isadmin)
        {
            isjoin = false;
            isadmin = false;
            string[] s = (login + " " + password).Split(' ');
            foreach (var user in users)
            {
                if (user.UserName == s[0] && user.UserPassword == s[1])
                {
                    if (user.Role == "admin")
                    {
                        isadmin = true;
                    }
                    isjoin = true;
                    break;
                }
            }
        }
        public void Register(User user, string Login, string Password)
        {
            user.UserName = Login;
            user.UserPassword = Password;
            user.Role = "client";
            User.users.Add(user);
            Console.Clear();
            Console.WriteLine("Успешная регистрация");
        }
    }
}
