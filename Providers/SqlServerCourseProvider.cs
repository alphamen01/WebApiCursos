﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebApiCursos.Context;
using WebApiCursos.Interfaces;
using WebApiCursos.Models;

namespace WebApiCursos.Providers
{
	public class SqlServerCourseProvider : ICoursesProvider
	{
		public async Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
		{
			var db = new CoursesDbContext();
			db.Courses.Add(course);
			var newId = await db.SaveChangesAsync();
			return(true, newId);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var db = new CoursesDbContext();
			var result = db.Courses.Where(c => c.Id == id).FirstOrDefault();
			if (result == null) {
				return false;
			} 
            
			db.Courses.Remove(result);
			await db.SaveChangesAsync();
			return true;
            
        }

		public async Task<Course> EliminarAsync(int id)
		{
			var db = new CoursesDbContext();
			var result = await db.Courses.FirstOrDefaultAsync(c =>
			c.Id == id);
			if (result != null) { 
				db.Courses.Remove(result);
				await db.SaveChangesAsync();
				return result;
			}

			return null;
		}

		public async Task<ICollection<Course>> GetAllAsync()
		{
			var db = new CoursesDbContext();
			var results = await db.Courses.ToListAsync();
			return results;
		}

		public async Task<Course> GetAsync(int id)
		{
			var db = new CoursesDbContext();
			var result = await db.Courses.FirstOrDefaultAsync(c =>
			c.Id == id);
			return result;
		}

		public async Task<ICollection<Course>> SearchAsync(string search)
		{
			var db = new CoursesDbContext();
			var raw = db.Courses.FromSqlRaw($"SELECT * FROM Courses WHERE Name LIKE '%{search}%'");
			var results = await raw.ToListAsync();
			return results;
		}

		public async Task<bool> UpdateAsync(int id, Course course)
		{
			var db = new CoursesDbContext();
			db.Courses.Update(course);
			var result = await db.SaveChangesAsync();
			return result == 1;
		}
	}
}
