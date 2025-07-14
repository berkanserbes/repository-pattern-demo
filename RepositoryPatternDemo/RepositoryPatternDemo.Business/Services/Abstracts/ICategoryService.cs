using RepositoryPatternDemo.Business.Requests.CategoryRequests;
using RepositoryPatternDemo.Business.Responses;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Services.Abstracts;

public interface ICategoryService
{
	Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges = false);
	Task<Category?> GetCategoryByIdAsync(int id, bool trackChanges = false);
	Task<CategoryResponse?> GetCategoryByIdWithProductsAsync(int id);
	Task CreateCategoryAsync(CreateCategoryRequest request);
	Task UpdateCategoryAsync(UpdateCategoryRequest request);
	Task DeleteCategoryAsync(DeleteCategoryRequest request);
}
