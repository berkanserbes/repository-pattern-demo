namespace RepositoryPatternDemo.Business.Services.Abstracts;

public interface IServiceManager
{
	IProductService ProductService { get; }
	ICategoryService CategoryService { get; }
}
