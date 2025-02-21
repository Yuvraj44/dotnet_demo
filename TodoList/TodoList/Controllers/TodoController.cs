using Microsoft.AspNetCore.Mvc;


namespace TodoList.Controllers
{


    

    [ApiController]
    [Route("todo")]
    public class HomeController : Controller
    {
        private static List<TaskItem> todos = new();


        [HttpGet("home")]
        public IActionResult demo()
        {
            return Content("Hello World"); 
        }
    

    
        [HttpPost("add")]
        public IActionResult addTask([FromBody] TaskItem task)
        {
            todos.Add(task);
            return Created("/view/{task.Id}", task);
        }
    

    
        [HttpGet("view")]
        public IActionResult viewAll()
        {
            return Ok(todos);
        }

        [HttpGet("view/{id}")]
        public IActionResult view(int id)
        {
            var task = todos.FirstOrDefault(t => t.Id == id);
            return task == null ? NotFound($"Task with ID {id} not found.") : Ok(task);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id)
        {
            var task = todos.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound($"Task with ID {id} not found.");

            task.IsCompleted = !task.IsCompleted; 
            return Ok(task);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var task = todos.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound($"Task with ID {id} not found.");

            todos.Remove(task);
            return NoContent(); 
        }

    }
}
