using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("todo")]
    public class HomeController : Controller
    {
        private readonly TodoContext _context;

        public HomeController(TodoContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTask([FromBody] TaskItem task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return Created($"/todo/view/{task.Id}", task);
        }

        [HttpGet("view")]
        public async Task<IActionResult> ViewAll()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(tasks);
        }

        [HttpGet("view/{id}")]
        public async Task<IActionResult> View(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return task == null ? NotFound($"Task with ID {id} not found.") : Ok(task);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskItem updatedTask)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound($"Task with ID {id} not found.");

            task.IsCompleted = updatedTask.IsCompleted;

            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound($"Task with ID {id} not found.");

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
