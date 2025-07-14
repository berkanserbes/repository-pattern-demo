using RepositoryPatternDemo.Business.Services.Abstracts;
using RepositoryPatternDemo.DataAccess.Repositories.Abstracts;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Services.Concretes;

public class ProductService : IProductService
{
	private readonly IRepositoryManager _repositoryManager;

	public ProductService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task CreateProductAsync(Product product)
	{
		if (product is null)
			throw new ArgumentNullException(nameof(product), "Product cannot be null.");

		_repositoryManager.ProductRepository.Create(product);
		await _repositoryManager.SaveAsync();
	}

	public async Task DeleteProductAsync(object id)
	{
		Product? product = await _repositoryManager.ProductRepository.GetByIdAsync(id, true);

		if (product is null)
			throw new KeyNotFoundException($"Product with id {id} not found.");

		_repositoryManager.ProductRepository.Delete(product);
		await _repositoryManager.SaveAsync();
	}

	public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges = false)
	{
		return await _repositoryManager.ProductRepository.GetAllAsync(trackChanges);
	}

	public async Task<Product?> GetProductByIdAsync(object id, bool trackChanges = false)
	{
		return await _repositoryManager.ProductRepository.GetByIdAsync(id, trackChanges);
	}

	public async Task UpdateProductAsync(Product product)
	{
		if (product is null)
			throw new ArgumentNullException(nameof(product), "Product cannot be null.");

		var existing = await _repositoryManager.ProductRepository.GetByIdAsync(product.Id, true);
		if (existing is null)
			throw new KeyNotFoundException($"Product with id {product.Id} not found.");

		_repositoryManager.ProductRepository.Update(product);
		await _repositoryManager.SaveAsync();
	}
}