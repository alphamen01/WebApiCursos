using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PagerMaterial> GetAllMaterialsAsyncPaginado(int id, int page, int size)
        {
            var db = new CoursesDbContext();

            var pageSize = size;
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            var materials = await db.Materials.FromSqlRaw($"SELECT * FROM Materials WHERE CourseId = '{id}'").ToListAsync();
                /*.Skip((page - 1) * (int)pageSize)
                .Take((int)pageSize)
                .ToListAsync();*/

            var records = materials.Count();

            var results = new PagerMaterial(records, page, size)
            {
                Materials = materials

            };
            return results;

        }
    }
}
