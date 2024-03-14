using Microsoft.AspNetCore.Mvc;
using Unilevel_CDE_Dev.Models;
using Unilevel_CDE_Dev.Services;

namespace Unilevel_CDE_Dev.Controllers
{
    [Route("api/area")]
    public class AreaController : Controller
    {
        private AreaService areaService;

        public AreaController(AreaService _areaService)
        {
            areaService = _areaService;
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
                return Ok(areaService.FindId(id));
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
                return Ok(areaService.findAll());
            }
            catch
            {
                return BadRequest();
            }

        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Area area)
        {
            try
            {
                return Ok(new
                {
                    status = areaService.Create(area)
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
        public IActionResult Update([FromBody] Area area)
        {
            try
            {
                return Ok(new
                {
                    status = areaService.Update(area)
                });
            }
            catch
            {
                return BadRequest();

            }
        }
    }
}
