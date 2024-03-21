using Microsoft.AspNetCore.Mvc;
using Unilevel_CDE_Dev.Models;
using Unilevel_CDE_Dev.Services;

namespace Unilevel_CDE_Dev.Controllers
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private CategoryService categoryService;

        public CategoryController(CategoryService _categoryService)
        {
            this.categoryService = _categoryService;
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
                return Ok(categoryService.FindId(id));
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
                return Ok(categoryService.findAll());
            }
            catch
            {
                return BadRequest();
            }

        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Category category)
        {
            try
            {
                return Ok(new
                {
                    status = categoryService.Create(category)
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
        public IActionResult Update([FromBody] Category category)
        {
            try
            {
                return Ok(new
                {
                    status = categoryService.Update(category)
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
        public IActionResult Delete([FromBody] Category category)
        {
            try
            {
                var isDeleted = categoryService.Delete(category);
                if (isDeleted)
                    return Ok(new { status = "Category deleted successfully." });
                else
                    return NotFound(new { status = "Category not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while processing your request.", details = ex.Message });
            }
        }
    }
}
