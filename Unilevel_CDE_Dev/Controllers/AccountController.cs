using Microsoft.AspNetCore.Mvc;
using Unilevel_CDE_Dev.Models;
using Unilevel_CDE_Dev.Services;

namespace Unilevel_CDE_Dev.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private AccountService accountService;
        private IWebHostEnvironment webHostEnvironment;

        public IActionResult Index()
        {
            return View();
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Account account)
        {
            try
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                return Ok(new
                {
                    status = accountService.Create(account)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("login/{username}&{password}")]
        public IActionResult FindByCreated(string username, string password)
        {
            try
            {
                return Ok(new
                {
                    status = accountService.Login(username, password)
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
        public IActionResult Update([FromBody] Account account)
        {
            try
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                return Ok(new
                {
                    status = accountService.Update(account)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
