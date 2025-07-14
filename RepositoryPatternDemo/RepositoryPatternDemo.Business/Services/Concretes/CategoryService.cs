using Microsoft.EntityFrameworkCore;
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

	public async Task CreateCategoryAsync(Category category)
	{
		if(category is null)
			throw new ArgumentNullException(nameof(category), "Category cannot be null.");

		_repositoryManager.CategoryRepository.Create(category);
		await _repositoryManager.SaveAsync();
	}

	public async Task DeleteCategoryAsync(object id)
	{
		Category? category = await _repositoryManager.CategoryRepository.GetByIdAsync(id, true);

		if (category is null)
			throw new KeyNotFoundException($"Category with id {id} not found.");

		_repositoryManager.CategoryRepository.Delete(category);
		await _repositoryManager.SaveAsync();
	}

	public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges = false)
	{
		return await _repositoryManager.CategoryRepository.GetAllAsync(trackChanges);
	}

	public async Task<Category?> GetCategoryByIdAsync(object id, bool trackChanges = false)
	{
		return await _repositoryManager.CategoryRepository.GetByIdAsync(id, trackChanges);
	}

	public async Task UpdateCategoryAsync(Category category)
	{
		if (category is null)
			throw new ArgumentNullException(nameof(category), "Category cannot be null.");

		var existing = await _repositoryManager.CategoryRepository.GetByIdAsync(category.Id, true);
		if (existing is null)
			throw new KeyNotFoundException($"Category with id {category.Id} not found.");

		_repositoryManager.CategoryRepository.Update(category);
		await _repositoryManager.SaveAsync();
	}
}
