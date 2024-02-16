using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkManagerWebApi.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        [HttpPost("assign")]
        public async Task<ActionResult> AssingTaskAsync()
        {
            return StatusCode(501);
        }
    }
}
