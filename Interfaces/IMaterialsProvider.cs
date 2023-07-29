using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCursos.Models;

namespace WebApiCursos.Interfaces
{
	public interface IMaterialsProvider
	{
		Task<ICollection<Material>> GetAllMaterialsAsync(int id);
	}
}
