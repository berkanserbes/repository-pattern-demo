using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.DataAccess.DbContexts;
using RepositoryPatternDemo.DataAccess.Repositories.Abstracts;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.DataAccess.Repositories.Concretes;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
	public CategoryRepository(AppDbContext context) : base(context)
	{
	}

	public async Task<Category?> GetCategoryByIdWithProducts(int id)
	{
		return await _context.Categories
			.Include(c => c.Products)
			.FirstOrDefaultAsync(c => c.Id.Equals(id));
	}
}
