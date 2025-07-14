using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Services.Abstracts;

public interface ICategoryService
{
	Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges = false);
	Task<Category?> GetCategoryByIdAsync(object id, bool trackChanges = false);
	Task CreateCategoryAsync(Category category);
	Task UpdateCategoryAsync(Category category);
	Task DeleteCategoryAsync(object id);
}
