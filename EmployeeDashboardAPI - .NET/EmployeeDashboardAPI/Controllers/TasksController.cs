using Microsoft.AspNetCore.Mvc;
using EmployeeDashboardAPI.Models;

namespace EmployeeDashboardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        
        private static List<TaskModel> tasks = new List<TaskModel>
        {
            new TaskModel
            {
                Id = 1,
                Title = "Create Login Page",
                Status = "Completed",
                Priority = "High"
            },

            new TaskModel
            {
                Id = 2,
                Title = "Implement Sidebar",
                Status = "In Progress",
                Priority = "Medium"
            },

            new TaskModel
            {
                Id = 3,
                Title = "Responsive UI",
                Status = "Pending",
                Priority = "High"
            },

            new TaskModel
            {
                Id = 4,
                Title = "API Integration",
                Status = "Completed",
                Priority = "Low"
            }
        };

        
        [HttpGet]
        public IActionResult GetTasks(string? status)
        {
            var filteredTasks = tasks;

            if (!string.IsNullOrEmpty(status))
            {
                filteredTasks = tasks
                    .Where(t =>
                        t.Status.ToLower() ==
                        status.ToLower())
                    .ToList();
            }

            return Ok(filteredTasks);
        }


        [HttpPost]
        public IActionResult AddTask(
     [FromBody] TaskModel task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            tasks.Add(task);

            return Ok(task);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task =
                tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            tasks.Remove(task);

            return Ok();
        }

       
        [HttpPut("{id}")]
        public IActionResult UpdateTask(
            int id,
            TaskModel updatedTask)
        {
            var task =
                tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            task.Title = updatedTask.Title;
            task.Status = updatedTask.Status;
            task.Priority = updatedTask.Priority;

            return Ok(task);
        }
    }
}