using RepositoryPatternDemo.DataAccess.DbContexts;
using RepositoryPatternDemo.DataAccess.Repositories.Abstracts;

namespace RepositoryPatternDemo.DataAccess.Repositories.Concretes;

public class RepositoryManager : IRepositoryManager
{
	private readonly AppDbContext _context;
	private readonly ICategoryRepository _categoryRepository;
	private readonly IProductRepository _productRepository;

	public RepositoryManager(
		AppDbContext context,
		ICategoryRepository categoryRepository,
		IProductRepository productRepository)
	{
		_context = context;
		_categoryRepository = categoryRepository;
		_productRepository = productRepository;
	}

	public ICategoryRepository CategoryRepository => _categoryRepository;
	public IProductRepository ProductRepository => _productRepository;

	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}
}
