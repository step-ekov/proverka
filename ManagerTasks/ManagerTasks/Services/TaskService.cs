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
            Console.Write("Дата окончания задачи: (пример: 2025-12-31/21.12.2025) ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Статус(В работе\\Закрыта) задачи: ");
            string status = Console.ReadLine();

            int newId = user.taskItems.Any() ? user.taskItems.Max(t => t.Id) + 1 : 1;
            user.taskItems.Add(new TaskItem(newId, Title, Description, date, status));
            Console.Clear();
            Console.WriteLine("Задача успешно добавлена");
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
                Console.WriteLine($"Номер задачи: {task.Id}\nНазвание: {task.Title}\nОписание: {task.Description}\nДата окончания: {task.DueDate.ToShortDateString()}\nСтатус: {task.Status}");
                Console.WriteLine();
            }
        }
    }
}
