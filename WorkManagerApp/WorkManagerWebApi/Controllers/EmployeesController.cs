using Core.Entities.RequestParametrs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Core.Interfaces;

namespace WorkManagerWebApi.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public EmployeesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetEmployeesAsync([FromQuery] string? department, [FromQuery] bool? busy)
        {
            try
            {
                var productsResult = await _serviceManager.EmployeesService.GetEmployeesAsync(department, busy);
                return Ok(productsResult);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
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
