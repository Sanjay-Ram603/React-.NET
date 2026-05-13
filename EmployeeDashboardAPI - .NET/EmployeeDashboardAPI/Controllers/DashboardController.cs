using Microsoft.AspNetCore.Mvc;
using EmployeeDashboardAPI.Models;

namespace EmployeeDashboardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDashboardData()
        {
            var data = new DashboardModel
            {
                TotalTasks = 12,
                CompletedTasks = 8,
                PendingTasks = 4
            };

            return Ok(data);
        }
    }
}