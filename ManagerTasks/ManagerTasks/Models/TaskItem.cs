using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTasks.Models
{
    public class TaskItem
    {
        public TaskItem() { }
        public TaskItem(int id, string title, string description, DateTime duedate, string status)
        {
            Id = id; 
            Title = title; 
            Description = description;
            DueDate = duedate;
            Status = status;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
