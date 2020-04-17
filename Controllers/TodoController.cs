using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServiceSV1.Models;
using System.Data.SqlClient;
namespace WebServiceSV1.Todo1
{
    [Route("api/todo")]
    public class TodoController : Controller
    {
        public TodoController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }
        public ITodoRepository TodoItems { get; set; }

        [HttpGet] //FIND
        public string Find([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return "";
            }
            string res= TodoItems.Find(item);
            return res;
        }


        [HttpPost] //CREATE
        public string Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return "";
            }
            string res = TodoItems.Add(item);
            return res;
        }

        [HttpPut] //ARCHIVE
        public string Archive([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return "";
            }
            string res = TodoItems.Archive(item);
            return res;
        }


        [HttpPatch] //UPDATE
        public string Update([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return "";
            }
            string res = TodoItems.Update(item);
            return res;
        }


        [HttpDelete] //DELETE
        public IActionResult Delete([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            TodoItems.Remove(item);
             return new NoContentResult();
        }
    }
    [Route("api/todo/getall")]
    public class TodoController2 : Controller
    {
        public TodoController2(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }
        public ITodoRepository TodoItems { get; set; }
        
        [HttpGet]
        public string GetAll([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return "";
            }
            string res = TodoItems.GetAll(item);
            return res;
        }
    }
}
