using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkManagerWebApi.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("list")]
        public async Task<ActionResult> GetEmployeesAsync()
        {
            return StatusCode(501);
        }

        [HttpGet("isbusy")]
        public async Task<ActionResult> GetBusyEmployeeAsync()
        {
            return StatusCode(501);
        }

        [HttpPost("assign")]
        public async Task<ActionResult> AssignTaskAsync()
        {
            return StatusCode(501);
        }
    }
}
