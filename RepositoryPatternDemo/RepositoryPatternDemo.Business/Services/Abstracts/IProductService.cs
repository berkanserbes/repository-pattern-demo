using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.Business.Services.Abstracts;

public interface IProductService
{
	Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges = false);
	Task<Product?> GetProductByIdAsync(object id, bool trackChanges = false);
	Task CreateProductAsync(Product product);
	Task UpdateProductAsync(Product product);
	Task DeleteProductAsync(object id);
}
