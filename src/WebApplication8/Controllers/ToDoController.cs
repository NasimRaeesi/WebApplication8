using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        public ToDoController(ITodoRepository todo)
        {
            todoItems = todo;
        }
        // GET: api/values
        public ITodoRepository todoItems { get; set; }

        [HttpGet]
        public IEnumerable<ToDoItem> GetAll()
        {
            return todoItems.GetAll();
        }

        [HttpGet("{id}",Name ="GetTodo")]
        public ActionResult GetById(string Id)
        {
            var item = todoItems.Find(Id);
            if (item == null)
            {
                NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ToDoItem item)
        {
            if (item==null)
            {
              return  BadRequest();
            }
            todoItems.Add(item);
            return CreatedAtRoute("GetToDo", new { id = item.Code }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] ToDoItem item)
        {
            if (item == null || item.Code!=id )
            {
                return BadRequest();
            }
            todoItems.Edit(item);
            return new NoContentResult();
        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] ToDoItem item,string id)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var todo = todoItems.Find(id);
            if (todo == null)
                NotFound();
            todoItems.Edit(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {

            var todo = todoItems.Find(id);
            todoItems.Remove(id);
            if (todo == null)
                NotFound();
            return new NoContentResult();
        }
    }
}
