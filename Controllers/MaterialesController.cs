using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCursos.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MaterialesController : ControllerBase
	{

		private readonly IMaterialsProvider materialsProvider;

		public MaterialesController(IMaterialsProvider materialsProvider)
		{
			this.materialsProvider = materialsProvider;
		}


		// GET: api/<MaterialesController>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAllMaterialsAsync(int id)
		{
			var results = await materialsProvider.GetAllMaterialsAsync(id);
			if (results != null)
			{
				return Ok(results);
			}
			return NotFound(id);

		}

		// GET api/<MaterialesController>/5
		[HttpGet("paginado")]
        public async Task<IActionResult> GetAllMaterialsAsyncPaginado(int id, int page, int size)
        {
            var results = await materialsProvider.GetAllMaterialsAsyncPaginado(id,page, size);
            if (results != null)
            {
                return Ok(results);
            }
            return NotFound();
        }

		// POST api/<MaterialesController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<MaterialesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<MaterialesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
