using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Business.Requests.CategoryRequests;
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
	public async Task<IActionResult> GetCategoryById([FromRoute] int id)
	{
		var category = await _serviceManager.CategoryService.GetCategoryByIdAsync(id);
		if (category == null)
			return NotFound();
		return Ok(category);
	}

	[HttpGet("with-products/{id}")]
	public async Task<IActionResult> GetCategoryByIdWithProducts([FromRoute] int id)
	{
		var category = await _serviceManager.CategoryService.GetCategoryByIdWithProductsAsync(id);
		if (category == null)
			return NotFound();
		return Ok(category);
	}

	[HttpPost]
	public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
	{
		if (request == null)
			return BadRequest("Category cannot be null.");
		await _serviceManager.CategoryService.CreateCategoryAsync(request);
		return Ok("Category created successfully.");
	}

	[HttpPut]
	public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
	{
		if (request == null)
			return BadRequest("Category cannot be null.");
		await _serviceManager.CategoryService.UpdateCategoryAsync(request);
		return Ok("Category updated successfully.");
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteCategory(DeleteCategoryRequest request)
	{
		try
		{
			await _serviceManager.CategoryService.DeleteCategoryAsync(request);
			return Ok("Category deleted successfully.");
		}
		catch (KeyNotFoundException)
		{
			return NotFound($"Category with id {request.Id} not found.");
		}
	}

}
