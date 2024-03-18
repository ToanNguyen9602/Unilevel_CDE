using Microsoft.AspNetCore.Mvc;
using Unilevel_CDE_Dev.Models;
using Unilevel_CDE_Dev.Services;

namespace Unilevel_CDE_Dev.Controllers
{
    [Route("api/positiongroup")]
    public class PositionGroupController : Controller
    {
        private PositionGroupService positionGroupService;
        public PositionGroupController(PositionGroupService _positionGroupService)
        {
            positionGroupService = _positionGroupService;
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
                return Ok(positionGroupService.FindId(id));
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
                return Ok(positionGroupService.findAll());
            }
            catch
            {
                return BadRequest();
            }

        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] PositionGroup positionGroup)
        {
            try
            {
                return Ok(new
                {
                    status = positionGroupService.Create(positionGroup)
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
        public IActionResult Update([FromBody] PositionGroup positionGroup)
        {
            try
            {
                return Ok(new
                {
                    status = positionGroupService.Update(positionGroup)
                });
            }
            catch
            {
                return BadRequest();

            }
        }
    }
}
