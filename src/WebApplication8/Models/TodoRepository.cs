using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace WebApplication8.Models
{
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, ToDoItem> todos = new ConcurrentDictionary<string, ToDoItem>();
        public   TodoRepository()
        {
            Add(new ToDoItem { Name = "Nasim" });
        }


        public void Add(ToDoItem item)
        {
            item.Code = Guid.NewGuid().ToString();
            todos[item.Code] = item;
        }

        public void Edit(ToDoItem item)
        {
            todos[item.Code] = item;
        }

        public ToDoItem Find(string Key)
        {
            ToDoItem item;
          todos.TryGetValue(Key, out item);
            return item;
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return todos.Values;
        }

        public ToDoItem Remove(string Key)
        {
            ToDoItem item;
            todos.TryRemove(Key, out item);
            return item;
        }
    }
}
