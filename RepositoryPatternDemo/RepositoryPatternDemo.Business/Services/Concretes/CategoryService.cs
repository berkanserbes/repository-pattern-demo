using RepositoryPatternDemo.Business.Requests.CategoryRequests;
using RepositoryPatternDemo.Business.Responses;
using RepositoryPatternDemo.Business.Services.Abstracts;
using RepositoryPatternDemo.DataAccess.Repositories.Abstracts;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Services.Concretes;

public class CategoryService : ICategoryService
{
	private readonly IRepositoryManager _repositoryManager;

	public CategoryService(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task CreateCategoryAsync(CreateCategoryRequest request)
	{
		if (request is null)
			throw new ArgumentNullException(nameof(request), "Category cannot be null.");

		Category category = new Category
		{
			Name = request.Name,
		};

		_repositoryManager.CategoryRepository.Create(category);
		await _repositoryManager.SaveAsync();
	}

	public async Task DeleteCategoryAsync(DeleteCategoryRequest request)
	{
		Category? category = await _repositoryManager.CategoryRepository.GetByIdAsync(request.Id, true);

		if (category is null)
			throw new KeyNotFoundException($"Category with id {request.Id} not found.");

		_repositoryManager.CategoryRepository.Delete(category);
		await _repositoryManager.SaveAsync();
	}

	public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges = false)
	{
		return await _repositoryManager.CategoryRepository.GetAllAsync(trackChanges);
	}

	public async Task<Category?> GetCategoryByIdAsync(int id, bool trackChanges = false)
	{
		return await _repositoryManager.CategoryRepository.GetByIdAsync(id, trackChanges);
	}

	public async Task<CategoryResponse?> GetCategoryByIdWithProductsAsync(int id)
	{
		var category = await _repositoryManager.CategoryRepository.GetCategoryByIdWithProducts(id);

		if (category is null)
			return null;

		var response = new CategoryResponse(
			Id: category.Id,
			Name: category.Name,
			Products: category.Products.Select(p => new ProductResponse(
				Id: p.Id,
				Name: p.Name,
				Price: p.Price
			)).ToList()
		);

		return response;
	}

	public async Task UpdateCategoryAsync(UpdateCategoryRequest request)
	{
		if (request is null)
			throw new ArgumentNullException(nameof(request), "Category cannot be null.");

		var existing = await _repositoryManager.CategoryRepository.GetByIdAsync(request.Id, true);
		if (existing is null)
			throw new KeyNotFoundException($"Category with id {request.Id} not found.");

		existing.Name = request.Name;

		_repositoryManager.CategoryRepository.Update(existing);
		await _repositoryManager.SaveAsync();
	}
}
