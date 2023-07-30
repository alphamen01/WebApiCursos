using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCursos.Models;

namespace WebApiCursos.Interfaces
{
	public interface IMaterialsProvider
	{
		Task<ICollection<Material>> GetAllMaterialsAsync(int id);
        Task<PagerMaterial> GetAllMaterialsAsyncPaginado(int id, int page, int size);
    }
}
