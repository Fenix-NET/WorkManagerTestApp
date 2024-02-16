using Core.Entities.RequestParametrs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WorkManagerWebApi.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("list")]
        public async Task<ActionResult> GetEmployeesAsync([FromQuery] string department, [FromQuery] bool busy)
        {
            return StatusCode(501);
        }

        [HttpGet("isbusy")]
        public async Task<ActionResult> GetBusyEmployeeAsync([FromQuery, Required] Guid id)
        {
            return StatusCode(501);
        }

        [HttpPost("assign")]
        public async Task<ActionResult> AssignTaskAsync([FromBody] EmployeeAssignParams param)
        {
            return StatusCode(501);
        }
    }
}
