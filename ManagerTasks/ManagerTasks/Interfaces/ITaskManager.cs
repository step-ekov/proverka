using ManagerTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTasks.Interfaces
{
    public interface ITaskManager
    {
        void CreateTask(User user, TaskItem taskItems);
        void DeleteTask(User user);
        void ListTasks(User user);
    }
}
