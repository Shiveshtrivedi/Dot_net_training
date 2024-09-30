using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace Todo.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _context;
        public TodoController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetTodo()
        {
            var todo = await _context.UserTasks.ToListAsync();
            if (todo == null)
            {
                Console.WriteLine("value not found");
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTask>> GetTodoById(int id)
        {
            var todo = await _context.UserTasks.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]

        public async Task<IActionResult> CreateTask(UserTask userTask)
        {

            _context.UserTasks.Add(userTask);
            await _context.SaveChangesAsync();

            return Ok(userTask);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UserTask userTask)
        {

            if (id != userTask.TaskId)
            {

                return BadRequest("Task id mismatch");
            }
            _context.Entry(userTask).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var updatedTodo = await _context.UserTasks.FindAsync(id);
            return Ok(updatedTodo);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<UserTask>> DeleteTask(int id)
        {
            var todo = await _context.UserTasks.FindAsync(id);
            if (todo == null)
            {
                return BadRequest();
            }
            _context.UserTasks.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool TaskExists(int id)
        {
            return _context.UserTasks.Any(e => e.TaskId == id);
        }

        [HttpGet("byUser/{userId}")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetTasksByUserId(int userId)
        {
            var tasks = await _context.UserTasks.Where(t => t.UserId == userId).ToListAsync();

            if (tasks == null || !tasks.Any())
            {
                return Ok(new List<UserTask>());
            }
            return Ok(tasks);
        }
    }
}
