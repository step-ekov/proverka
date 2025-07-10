using ManagerTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTasks.Services
{
    public class UserService
    {
        private List<User> users = new List<User>
        {
            new User("test", "test1", "client"),
            new User("test0", "test0", "admin"),
            new User("t", "t", "admin")
        };

        public void ViewUsers()
        {
            foreach (var usr in users)
            {
                Console.WriteLine();
                Console.WriteLine($"Имя пользователя: {usr.UserName}\nПароль пользователя: {usr.UserPassword}\nРоль: {usr.Role}");
                Console.WriteLine();
            }
        }
        public User Login(string login, string password)
        {
            foreach (var u in users)
            {
                if (u.UserName == login && u.UserPassword == password)
                {
                    return u;
                }
            }
            return null;
        }
        public void Register(string Login, string Password)
        {
            if (users.Any(u => u.UserName == Login))
            {
                Console.Clear();
                Console.WriteLine("Пользователь с таким именем уже существует.");
                return;
            }
            User user = new User
            {
                UserName = Login,
                UserPassword = Password,
                Role = "client"
            };
            users.Add(user);
            Console.Clear();
            Console.WriteLine("Успешная регистрация");
        }
    }
}
