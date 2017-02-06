using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
   public interface   ITodoRepository
    {
        void Add(ToDoItem item);
        void Edit(ToDoItem item);

        ToDoItem Find(string Key);
        ToDoItem Remove(string Key);

        IEnumerable<ToDoItem> GetAll();
    }
}
