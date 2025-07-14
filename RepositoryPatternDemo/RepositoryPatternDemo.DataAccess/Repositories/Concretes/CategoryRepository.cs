using RepositoryPatternDemo.DataAccess.DbContexts;
using RepositoryPatternDemo.DataAccess.Repositories.Abstracts;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.DataAccess.Repositories.Concretes;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
	public CategoryRepository(AppDbContext context) : base(context)
	{
	}
}
