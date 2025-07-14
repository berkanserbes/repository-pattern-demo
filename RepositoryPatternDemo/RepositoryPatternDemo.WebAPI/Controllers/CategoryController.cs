using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Business.Services.Abstracts;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public CategoryController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllCategories()
	{
		var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync();
		return Ok(categories);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetCategoryById(object id)
	{
		var category = await _serviceManager.CategoryService.GetCategoryByIdAsync(id);
		if (category == null)
			return NotFound();
		return Ok(category);
	}

	[HttpPost]
	public async Task<IActionResult> CreateCategory([FromBody] Category category)
	{
		if (category == null)
			return BadRequest("Category cannot be null.");
		await _serviceManager.CategoryService.CreateCategoryAsync(category);
		return Ok("Category created successfully.");
	}

	[HttpPut]
	public async Task<IActionResult> UpdateCategory([FromBody] Category category)
	{
		if (category == null)
			return BadRequest("Category cannot be null.");
		await _serviceManager.CategoryService.UpdateCategoryAsync(category);
		return Ok("Category updated successfully.");
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteCategory(object id)
	{
		try
		{
			await _serviceManager.CategoryService.DeleteCategoryAsync(id);
			return Ok("Category deleted successfully.");
		}
		catch (KeyNotFoundException)
		{
			return NotFound($"Category with id {id} not found.");
		}
	}

}
