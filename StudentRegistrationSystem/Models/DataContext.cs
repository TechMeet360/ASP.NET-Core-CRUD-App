
namespace StudentRegistrationSystem.Models
{
	using System.IO;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;

	public class DataContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");
			var configuration = builder.Build();
			optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
		}

		public DbSet<StudentViewModel> Student { get; set; }
	}
}
