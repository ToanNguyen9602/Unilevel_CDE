using Microsoft.AspNetCore.Mvc;
using Unilevel_CDE_Dev.Models;
using Unilevel_CDE_Dev.Services;

namespace Unilevel_CDE_Dev.Controllers
{
    [Route("api/distributor")]
    public class Distributor : Controller
    {
        private DistributorService distributorService;

        public Distributor(DistributorService _distributorService)
        {
            distributorService = _distributorService;
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
                return Ok(distributorService.FindId(id));
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
                return Ok(distributorService.findAll());
            }
            catch
            {
                return BadRequest();
            }

        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Models.Distributor distributor)
        {
            try
            {
                return Ok(new
                {
                    status = distributorService.Create(distributor)
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
        public IActionResult Update([FromBody] Models.Distributor distributor)
        {
            try
            {
                return Ok(new
                {
                    status = distributorService.Update(distributor)
                });
            }
            catch
            {
                return BadRequest();

            }
        }
    }
}
