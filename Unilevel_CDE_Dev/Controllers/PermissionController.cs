using Microsoft.AspNetCore.Mvc;
using Unilevel_CDE_Dev.Models;
using Unilevel_CDE_Dev.Services;

namespace Unilevel_CDE_Dev.Controllers
{
    [Route("api/permission")]
    public class PermissionController : Controller
    {
        private PermissionService permissionService;

        public PermissionController(PermissionService _permissionService)
        {
            this.permissionService = _permissionService;
        }

        [HttpGet("demo1")]
        [Produces("application/json")]
        public IActionResult Demo1()
        {
            try
            {
                return Ok(new
                {
                    Msg = "Hello World!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Route("find/{id}")]
        public IActionResult Find(int id)
        {
            try
            {
                return Ok(permissionService.FindId(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Route("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(permissionService.findAll());
            }
            catch
            {
                return BadRequest();
            }

        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Permission permission)
        {
            try
            {
                return Ok(new
                {
                    status = permissionService.Create(permission)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("update")]
        public IActionResult Update([FromBody] Permission permission)
        {
            try
            {
                return Ok(new
                {
                    status = permissionService.Update(permission)
                });
            }
            catch
            {
                return BadRequest();

            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] Permission permission)
        {
            try
            {
                var isDeleted = permissionService.Delete(permission);
                if (isDeleted)
                    return Ok(new { status = "Permission deleted successfully." });
                else
                    return NotFound(new { status = "Permission not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }
    }
}
