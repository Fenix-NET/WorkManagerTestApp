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
                var employees = await _serviceManager.EmployeesService.GetEmployeesAsync(department, busy);

                return Ok(employees);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("isbusy")]
        public async Task<ActionResult> GetBusyEmployeeAsync([FromQuery, Required] Guid id)
        {
            try
            {
                var employee = await _serviceManager.EmployeesService.GetBusyEmployeeAsync(id);
                if (employee != null)
                    return Ok(employee.Busy);
                else
                    return NotFound($"Сотрудник с id {id} не найден");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("assign")]
        public async Task<ActionResult> AssignTaskAsync([FromBody] EmployeeAssignParams param)
        {
            try
            {
                var employee = await _serviceManager.EmployeesService.GetEmployeeByIdAsync(param.Id);
                if (employee == null)
                {
                    return NotFound($"Сотрудник с id {param.Id} не найден");
                }

                if (employee.Busy == true)
                {
                    return StatusCode(500, "В выбранное время сотрудник занят");
                }
                else
                {
                    await _serviceManager.EmployeesService.AssignTaskWithCheck(employee, param.StartAt);
                    return Ok();
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
