using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCursos.Context;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

namespace WebApiCursos.Providers
{
	public class SqlServerMaterialProvider : IMaterialsProvider
	{
		public async Task<ICollection<Material>> GetAllMaterialsAsync(int id)
		{
			var db = new CoursesDbContext();
			var raw = db.Materials.FromSqlRaw($"SELECT * FROM Materials WHERE CourseId = '{id}'");
			var results = await raw.ToListAsync();
			return results;
		}
	}
}
