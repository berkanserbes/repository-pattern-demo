using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.DataAccess.DbContexts;
using RepositoryPatternDemo.DataAccess.Repositories.Abstracts;
using System.Linq.Expressions;

namespace RepositoryPatternDemo.DataAccess.Repositories.Concretes;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
	internal readonly AppDbContext _context;
	internal DbSet<TEntity> _dbSet;

	public BaseRepository(AppDbContext context)
	{
		_context = context;
		_dbSet = _context.Set<TEntity>();
	}

	public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool trackChanges = false)
	{
		if (trackChanges)
			return _dbSet.Where(predicate);

		return _dbSet
			.AsNoTracking()
			.Where(predicate);
	}

	public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false)
	{
		if(trackChanges)
			return await _dbSet.ToListAsync();

		return await _dbSet.AsNoTracking().ToListAsync();
	}

	public async Task<TEntity?> GetByIdAsync(int id, bool trackChanges = false)
	{
		var entity = await _dbSet.FindAsync(id);
		if (!trackChanges && entity != null)
			_context.Entry(entity).State = EntityState.Detached;

		return entity;
	}

	public void Create(TEntity entity)
	{
		_dbSet.Add(entity);
	}
	public void Update(TEntity entity)
	{
		_dbSet.Update(entity);
	}
	public void Delete(TEntity entity)
	{
		_dbSet.Remove(entity);
	}
}
