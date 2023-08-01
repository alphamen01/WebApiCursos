using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using WebApiCursos.Context;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

namespace WebApiCursos.Providers
{
	public class SqlServerCourseProvider : ICoursesProvider
	{
		private readonly CoursesDbContext context;

        public SqlServerCourseProvider(CoursesDbContext context)
        {
            this.context = context;
        }

        public async Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
		{
			//var db = new CoursesDbContext();
			context.Courses.Add(course);
			var newId = await context.SaveChangesAsync();
			return(true, newId);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			//var db = new CoursesDbContext();
			var result = context.Courses.Where(c => c.Id == id).FirstOrDefault();
			if (result == null) {
				return false;
			} 
            
			context.Courses.Remove(result);
			await context.SaveChangesAsync();
			return true;
            
        }

		public async Task<Course> EliminarAsync(int id)
		{
			//var db = new CoursesDbContext();
			var result = await context.Courses.FirstOrDefaultAsync(c =>
			c.Id == id);
			if (result != null) { 
				context.Courses.Remove(result);
				await context.SaveChangesAsync();
				return result;
			}

			return null;
		}

		public async Task<ICollection<Course>> GetAllAsync()
		{
			//var db = new CoursesDbContext();
			var results = await context.Courses.ToListAsync();
			return results;
		}

        public async Task<ICollection<Course>> GetAllAsyncPag(int pageSize, int pageNumber)
        {
            //var db = new CoursesDbContext();
            var results = await context.Courses.ToListAsync();
            var paginatedItems = results
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            return paginatedItems;
        }

        public async Task<Pager> GetAllAsyncPaginado(int page,int size)
        {
            /*
			  var db = new CoursesDbContext();

			var pageSize = size;
            var pageCount = Math.Ceiling(db.Courses.Count() / (decimal)pageSize);
			var records = db.Courses.Count();

            var courses = await db.Courses
                .Skip((page - 1) * (int)pageSize)
				.Take((int)pageSize)
				.ToListAsync();

            var results = new Pager
            {
                Courses = courses,
                CurrentPage = page,
                Pages = (int)pageCount,
				Records = records
            };

            return results;			 
			 */
            //var db = new CoursesDbContext();

			var pageSize = size;
			if (pageSize < 1)
			{
				pageSize = 1;
			}
			var records = context.Courses.Count();
			var courses = await context.Courses
                .Skip((page - 1) * (int)pageSize)
				.Take((int)pageSize)
				.ToListAsync();

            var results = new Pager(records, page, size)
			{
				Courses = courses

			};
			return results;			                      
        }
        public async Task<Course> GetAsync(int id)
		{
			//var db = new CoursesDbContext();
			var result = await context.Courses.FirstOrDefaultAsync(c =>
			c.Id == id);
			return result;
		}

		public async Task<ICollection<Course>> SearchAsync(string search)
		{
			//var db = new CoursesDbContext();
			var raw = context.Courses.FromSqlRaw($"SELECT * FROM Courses WHERE Name LIKE '%{search}%'");


			var results = await raw.ToListAsync();
			return results;
		}

        public async Task<Pager> SearchAsyncPaginado(string search, int page, int size)
        {
            //var db = new CoursesDbContext();
            var raw = context.Courses.FromSqlRaw($"SELECT * FROM Courses WHERE Name LIKE '%{search}%'");
            var records = await raw.CountAsync();
			//int page = 1;
			//int size = 3;

            var results = await raw.Skip((page - 1) * size).Take(size).ToListAsync();
            

            var pager = new Pager(records, page, size)
            {
                Courses = results

            };
            return pager;
        }

        public async Task<bool> UpdateAsync(int id, Course course)
		{
			//var db = new CoursesDbContext();
			context.Courses.Update(course);
			var result = await context.SaveChangesAsync();
			return result == 1;
		}
	}
}
