using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiCursos.Interfaces;

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
		public IActionResult Get()
		{
			return Ok(10);
		}

		// GET api/<CursosController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CursosController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<CursosController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CursosController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
