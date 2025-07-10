using ManagerTasks.Interfaces;
using ManagerTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTasks.Services
{
    public class TaskService : ITaskManager
    {
        public void CreateTask(User user, TaskItem taskItem)
        {
            Console.Clear();
            Console.WriteLine("Введите данные:");

            Console.Write("Название задачи: ");
            string Title = Console.ReadLine();
            Console.Write("Описание задачи: ");
            string Description = Console.ReadLine();
            Console.Write("Дата окончания задачи: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Статус(В работе\\Закрыта) задачи: ");
            string status = Console.ReadLine();

            user.taskItems.Add(new TaskItem(user.taskItems.Count + 1, Title, Description, date, status));//id - Guid
            Console.WriteLine("Задача успешно добавлена");
            Console.Clear();
            Console.WriteLine("Меню:\n 1 - Посмотреть мои задачи\n 2 - Добавить задачу\n" +
            " 3 - Удалить задачу\n 4 - просмотреть все задачи(админ)\n 0 - Выход из меню");
        }
        public void DeleteTask(User user)
        {
            ListTasks(user);
            Console.Write("Выберете задачу для удаления: ");
            user.taskItems.RemoveAt(int.Parse(Console.ReadLine()) - 1);
            Console.WriteLine("Задача удалена");
            ListTasks(user);
        }
        public void ListTasks(User user)
        {
            Console.Clear();
            Console.WriteLine("Мои задачи"); Console.WriteLine();
            foreach (var task in user.taskItems)
            {
                Console.WriteLine($"Номер задачи: {task.Id}\nНазвание: {task.Title}\nОписание: {task.Description}\nДата окончания: {task.DueDate}\nСтатус: {task.Status}");
                Console.WriteLine();
            }
        }
    }
}
