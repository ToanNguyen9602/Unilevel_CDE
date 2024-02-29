using Microsoft.AspNetCore.Mvc;

namespace Unilevel_CDE_Dev.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private AccountService AccountService;
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
                    status = AccountService.Create(account)
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
                    status = AccountService.Login(username, password)
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
                    status = AccountService.Update(account)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
