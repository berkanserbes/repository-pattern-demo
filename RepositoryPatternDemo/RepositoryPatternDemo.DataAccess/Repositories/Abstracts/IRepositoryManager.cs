namespace RepositoryPatternDemo.DataAccess.Repositories.Abstracts;

public interface IRepositoryManager
{
	IProductRepository ProductRepository { get; }
	ICategoryRepository CategoryRepository { get; }
	Task SaveAsync();
}
