﻿
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCursos.Models;

namespace WebApiCursos.Interfaces
{
    public interface ICoursesProvider
    {
        Task<ICollection<Course>> GetAllAsync();
        Task<ICollection<Course>> SearchAsync(string search);
        Task<Course> GetAsync(int id);

        Task<bool> UpdateAsync(int id, Course  course);

        Task<(bool IsSuccess, int? Id)> AddAsync(Course course);

		Task<bool> DeleteAsync(int id);

		Task<Course> EliminarAsync(int id);

        Task<ICollection<Course>> GetAllAsyncPag(int pageSize, int pageNumber);

        Task<Pager> GetAllAsyncPaginado(int page, int size);

    }
}
