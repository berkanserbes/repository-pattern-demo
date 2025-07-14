using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Business.Requests.ProductRequests;
using RepositoryPatternDemo.Business.Services.Abstracts;

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
	public async Task<IActionResult> GetProductById(int id)
	{
		var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
		if (product == null)
			return NotFound();
		return Ok(product);
	}

	[HttpPost]
	public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
	{
		if (request == null)
			return BadRequest("Product cannot be null.");
		await _serviceManager.ProductService.CreateProductAsync(request);
		return Ok("Product created successfully.");
	}

	[HttpPut]
	public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
	{
		if (request == null)
			return BadRequest("Product cannot be null.");
		await _serviceManager.ProductService.UpdateProductAsync(request);
		return Ok("Product updated successfully.");
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteProduct(DeleteProductRequest request)
	{
		try
		{
			await _serviceManager.ProductService.DeleteProductAsync(request);
			return Ok("Product deleted successfully.");
		}
		catch (KeyNotFoundException)
		{
			return NotFound($"Product with id {request.Id} not found.");
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal server error: {ex.Message}");
		}
	}
}
