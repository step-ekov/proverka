using ManagerTasks.Models;
using ManagerTasks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTasks
{
    internal class Program
    {
        public const string ViewSystem = "ВХОД В СИСТЕМУ:\n0 - Выход\n1 - Зарегистрироваться\n2 - Войти";
        public const string ViewMenu = "Меню:\n 1 - Посмотреть мои задачи\n 2 - Добавить задачу\n 3 - Удалить задачу" +
            "\n 4 - просмотреть все задачи(админ)\n 0 - Выход из меню";
        public static bool _isadmin = false;

        static void Main(string[] args)
        {
            User user = new User();
            TaskItem taskItem = new TaskItem();
            UserService userService = new UserService();
            TaskService taskService = new TaskService();

            Console.WriteLine(ViewSystem);
            while (true)
            {
                int intVvod = ParseString();
                if (intVvod != -1)
                {
                    switch (intVvod)
                    {
                        case 0:
                            return;
                        case 1:
                            UserData ud = Vvod();
                            userService.Register(user, ud.Login, ud.Password);
                            Console.WriteLine(ViewSystem);
                            break;
                        case 2:
                            UserData ud1 = Vvod();
                            bool isjoin; bool isadmin;
                            userService.Login(ud1.Login, ud1.Password, out isjoin, out isadmin);
                            if (isjoin == true)
                            {
                                Console.Clear();
                                if (isadmin == true)
                                {
                                    _isadmin = isadmin;
                                }
                                Console.WriteLine("Успешный вход");
                                Menu(taskService, user, taskItem);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Неверные данные, попробуйте еще раз.");
                                Console.WriteLine(ViewSystem);
                            }
                            break;
                        default:
                            Console.WriteLine("Введите номер доступных действий!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Введите число.");
                }
            }
        }
        public static UserData Vvod()
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            return new UserData(login, password);
        }
        public static int ParseString()
        {
            string number = Console.ReadLine();
            int truenumber;

            if (int.TryParse(number, out truenumber))
                return truenumber;
            else
                return -1;
        }
        public static void Menu(TaskService taskService, User user, TaskItem taskItem)
        {
            Console.WriteLine(ViewMenu);
            //User user = new User();
            while (true)
            {
                int intVvod = ParseString();
                switch (intVvod)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine(ViewSystem);
                        return;
                    case 1:
                        taskService.ListTasks(user);
                        Console.WriteLine(ViewMenu);
                        break;
                    case 2:
                        taskService.CreateTask(user, taskItem);
                        break;
                    case 3:
                        taskService.DeleteTask(user);
                        Console.WriteLine(ViewMenu);
                        break;
                    case 4:
                        if (_isadmin == true)
                        {
                            Console.Clear();
                            taskService.ListTasks(user);
                            Console.WriteLine(ViewMenu);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Вы не админ!!!");
                            Console.WriteLine(ViewMenu);
                        }
                        break;
                }
            }
        }
    }
    class UserData
    {
        public UserData() { }
        public UserData(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
