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

        public AccountController(AccountService _accountService, IWebHostEnvironment _webHostEnvironment)
        {
            this.accountService = _accountService;
            this.webHostEnvironment = _webHostEnvironment;
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
            } catch (Exception ex)
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
                return Ok(accountService.FindId(id));
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
                return Ok(accountService.findAll());
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
