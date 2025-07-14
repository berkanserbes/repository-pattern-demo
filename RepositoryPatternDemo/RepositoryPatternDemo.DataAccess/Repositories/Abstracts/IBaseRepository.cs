using System.Linq.Expressions;

namespace RepositoryPatternDemo.DataAccess.Repositories.Abstracts;

public interface IBaseRepository<TEntity> where TEntity : class
{
	Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false);
	IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool trackChanges = false);
	Task<TEntity?> GetByIdAsync(int id, bool trackChanges = false);
	void Create(TEntity entity);
	void Update(TEntity entity);
	void Delete(TEntity entity);
}
