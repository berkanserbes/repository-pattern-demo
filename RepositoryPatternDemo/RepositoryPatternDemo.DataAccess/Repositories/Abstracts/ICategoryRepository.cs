﻿using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.DataAccess.Repositories.Abstracts;

public interface ICategoryRepository : IBaseRepository<Category>
{
	Task<Category?> GetCategoryByIdWithProducts(int id);
}
