using Microsoft.EntityFrameworkCore;
using WebApiCursos.Models;

namespace WebApiCursos.Context
{
	public class CoursesDbContext: DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=PROYCANVSIN19;Initial Catalog=Courses;User ID=sa;Password=Lesg2022;");
		}

		public DbSet<Course> Courses { get; set; }
    }
}
