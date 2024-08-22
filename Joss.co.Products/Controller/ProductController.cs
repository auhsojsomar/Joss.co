using Joss.co.Common.Services;
using Joss.co.Data.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Joss.co.Common
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductController : ControllerBase
  {
    private readonly IMongoDbService<Products> _mongoDbService;

    public ProductController(IMongoDbService<Products> mongoDbService)
    {
      _mongoDbService = mongoDbService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Products>>> GetAllProducts()
    {
      return Ok(await _mongoDbService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Products?>> GetProduct(Guid id)
    {
      var product = await _mongoDbService.GetAsync(id);

      if (product is null)
        return NotFound($"Product not found: {id}");

      return product;
    }

    [HttpPost]
    public async Task<ActionResult<Products>> CreateProduct(Products products)
    {
      try
      {
        return Ok(await _mongoDbService.CreateAsync(products));
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
  }
}