using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Business.Services.Abstracts;
using RepositoryPatternDemo.Domain.Entities;

namespace RepositoryPatternDemo.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
	private readonly IServiceManager _serviceManager;

	public ProductController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllProducts()
	{
		var products = await _serviceManager.ProductService.GetAllProductsAsync();
		return Ok(products);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetProductById(object id)
	{
		var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
		if (product == null)
			return NotFound();
		return Ok(product);
	}

	[HttpPost]
	public async Task<IActionResult> CreateProduct([FromBody] Product product)
	{
		if (product == null)
			return BadRequest("Product cannot be null.");
		await _serviceManager.ProductService.CreateProductAsync(product);
		return Ok("Product created successfully.");
	}

	[HttpPut]
	public async Task<IActionResult> UpdateProduct([FromBody] Product product)
	{
		if (product == null)
			return BadRequest("Product cannot be null.");
		await _serviceManager.ProductService.UpdateProductAsync(product);
		return Ok("Product updated successfully.");
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteProduct(object id)
	{
		try
		{
			await _serviceManager.ProductService.DeleteProductAsync(id);
			return Ok("Category deleted successfully.");
		}
		catch (KeyNotFoundException)
		{
			return NotFound($"Category with id {id} not found.");
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal server error: {ex.Message}");
		}
	}
}
