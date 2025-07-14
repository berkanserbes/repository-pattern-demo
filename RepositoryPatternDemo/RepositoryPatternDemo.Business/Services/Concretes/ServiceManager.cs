using RepositoryPatternDemo.Business.Services.Abstracts;

namespace RepositoryPatternDemo.Business.Services.Concretes;

public class ServiceManager : IServiceManager
{
	private IProductService _productService;
	private ICategoryService _categoryService;

	public ServiceManager(IProductService productService, ICategoryService categoryService)
	{
		_productService = productService;
		_categoryService = categoryService;
	}

	public IProductService ProductService => _productService;
	public ICategoryService CategoryService => _categoryService;
}
