using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

namespace WebApiCursos.Providers
{
	public class SqlServerCourseProvider : ICoursesProvider
	{
		public Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
		{
			throw new System.NotImplementedException();
		}

		public Task<ICollection<Course>> GetAllAsync()
		{
			throw new System.NotImplementedException();
		}

		public Task<Course> GetAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<ICollection<Course>> SearchAsync(string search)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> UpdateAsync(int id, Course course)
		{
			throw new System.NotImplementedException();
		}
	}
}
