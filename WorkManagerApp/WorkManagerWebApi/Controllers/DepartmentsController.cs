using Core.Entities.RequestParametrs;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkManagerWebApi.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public DepartmentsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("assign")]
        public async Task<ActionResult> AssignTaskAsync([FromBody] DepartmentAssignParams param)
        {
            try
            {
                var employee = await _serviceManager.EmployeesService.GetUnEmployees(param);

                if (employee != null)
                {
                    await _serviceManager.EmployeesService.AssignTask(employee);
                    return Ok();
                }
                else
                {
                    return BadRequest("Подходящий сотрудник не найден");
                }
                
                
            }
            catch
            {
                return StatusCode(500, "Unexpected error has occured");
            }
        }
    }
}
