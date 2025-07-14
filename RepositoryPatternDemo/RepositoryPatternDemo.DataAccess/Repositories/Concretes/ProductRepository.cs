using RepositoryPatternDemo.DataAccess.DbContexts;
using RepositoryPatternDemo.DataAccess.Repositories.Abstracts;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.DataAccess.Repositories.Concretes;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
	public ProductRepository(AppDbContext context) : base(context)
	{
	}
}
