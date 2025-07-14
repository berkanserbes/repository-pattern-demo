using RepositoryPatternDemo.Business.Requests.ProductRequests;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Services.Abstracts;

public interface IProductService
{
	Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges = false);
	Task<Product?> GetProductByIdAsync(int id, bool trackChanges = false);
	Task CreateProductAsync(CreateProductRequest request);
	Task UpdateProductAsync(UpdateProductRequest request);
	Task DeleteProductAsync(DeleteProductRequest request);
}
