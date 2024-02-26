using Demo.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private AccountService accountService;
        public IWebHostEnvironment webHostEnvironment;

        public AccountController(AccountService _accountService, IWebHostEnvironment _webHostEnvironment)
        {
            accountService = _accountService;
            webHostEnvironment = _webHostEnvironment;
        }

        [Produces("application/json")]
        [HttpGet("findbyid/{id}")]
        public IActionResult FindId(int id)
        {
            try
            {
                return Ok(accountService.FindId(id));
            }
            catch
            {
                return BadRequest();
            }
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
        public IActionResult FindByCreated(int id, string password)
        {
            try
            {
                return Ok(new
                {
                    status = accountService.Login(id, password)
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
