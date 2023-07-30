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
            var raw = db.Materials.FromSqlRaw($"SELECT * FROM Materials WHERE CourseId = '{id}'");
            var records = await raw.CountAsync();
            if (size < 1)
            {
                size = 1;
            }
            var results = await raw.Skip((page - 1) * size).Take(size).ToListAsync();
            
            var pagermaterials = new PagerMaterial(records, page, size)
            {
                Materials = results

            };
            return pagermaterials;

        }
    }
}
