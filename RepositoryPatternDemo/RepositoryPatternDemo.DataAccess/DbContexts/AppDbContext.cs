using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Domain.Entities;
using System.Reflection;

namespace RepositoryPatternDemo.DataAccess.DbContexts;

public class AppDbContext : DbContext
{
	public DbSet<Product> Products { get; set; }
	public DbSet<Category> Categories { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}
