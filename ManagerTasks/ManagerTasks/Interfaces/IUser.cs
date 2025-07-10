using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTasks.Interfaces
{
    public interface IUser
    {
        string UserName { get; set; }
        string UserPassword { get; set; }
        string Role { get; set; }
    }
}
