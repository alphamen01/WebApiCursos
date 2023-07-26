using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCursos.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CursosController : ControllerBase
	{
		private readonly ICoursesProvider coursesProvider;

		public CursosController(ICoursesProvider coursesProvider)
        {
			this.coursesProvider = coursesProvider;
		}


        // GET: api/<CursosController>
        [HttpGet]	
		public async Task<IActionResult> GetAllAsync()
		{
			var results = await coursesProvider.GetAllAsync();
            if (results != null)
            {
				return Ok(results);
            }
			return NotFound();
        }

        [HttpGet("pag")]
        public async Task<IActionResult> GetAllAsyncPag(int pageSize, int pageNumber)
        {
            var results = await coursesProvider.GetAllAsyncPag(pageSize,pageNumber);
            if (results != null)
            {
                return Ok(results);
            }
            return NotFound();
        }

        [HttpGet("paginado")]
        public async Task<IActionResult> GetAllAsyncPaginado(int page, int size)
        {
            var results = await coursesProvider.GetAllAsyncPaginado(page, size);
            if (results != null)
            {
                return Ok(results);
            }
            return NotFound();
        }

        // GET api/<CursosController>/5
        [HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(int id)
		{
			var result = await coursesProvider.GetAsync(id);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(id);

		}

		[HttpGet("search/{search}")]
		public async Task<IActionResult> SearchAsync(string search)
		{
			var results = await coursesProvider.SearchAsync(search);
			if (results != null)
			{
				return Ok(results);
			}
			return NotFound(search);
		}

		// POST api/<CursosController>
		[HttpPost]
		public async Task<IActionResult> AddAsync(Course course)
		{
            if (course == null)
            {
				return BadRequest();
            }
			var result = await coursesProvider.AddAsync(course);
			if (result.IsSuccess)
			{
				return Ok(result.Id);
			}
			return NotFound();
		}

		// PUT api/<CursosController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(int id, Course course)
		{
			var result = await coursesProvider.UpdateAsync(id, course);
			if (result)
			{
				return Ok();
			}
			return NotFound();
		}

		// DELETE api/<CursosController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await coursesProvider.EliminarAsync(id);
            if (result != null)
            {
				return NoContent();	
            }
            return NotFound();			
        }
	}
}
