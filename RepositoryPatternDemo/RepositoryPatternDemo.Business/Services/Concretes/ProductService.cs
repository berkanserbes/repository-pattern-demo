using RepositoryPatternDemo.Business.Requests.ProductRequests;
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

	public async Task CreateProductAsync(CreateProductRequest request)
	{
		if (request is null)
			throw new ArgumentNullException(nameof(request), "Product cannot be null.");

		var category = await _repositoryManager.CategoryRepository.GetByIdAsync(request.CategoryId, true);
		if (category is null)
			throw new ArgumentException($"Category with id {request.CategoryId} not found.");

		Product product = new Product
		{
			Name = request.Name,
			Price = request.Price,
			CategoryId = request.CategoryId
		};

		category.Products.Add(product);
		await _repositoryManager.SaveAsync();
	}

	public async Task DeleteProductAsync(DeleteProductRequest request)
	{
		Product? product = await _repositoryManager.ProductRepository.GetByIdAsync(request.Id, true);

		if (product is null)
			throw new ArgumentException($"Product with id {request.Id} not found.");

		_repositoryManager.ProductRepository.Delete(product);
		await _repositoryManager.SaveAsync();
	}

	public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges = false)
	{
		return await _repositoryManager.ProductRepository.GetAllAsync(trackChanges);
	}

	public async Task<Product?> GetProductByIdAsync(int id, bool trackChanges = false)
	{
		return await _repositoryManager.ProductRepository.GetByIdAsync(id, trackChanges);
	}

	public async Task UpdateProductAsync(UpdateProductRequest request)
	{
		if (request is null)
			throw new ArgumentNullException(nameof(request), "Product cannot be null.");

		var existing = await _repositoryManager.ProductRepository.GetByIdAsync(request.Id, true);
		if (existing is null)
			throw new KeyNotFoundException($"Product with id {request.Id} not found.");

		existing.Name = request.Name;
		existing.Price = request.Price;

		_repositoryManager.ProductRepository.Update(existing);
		await _repositoryManager.SaveAsync();
	}
}