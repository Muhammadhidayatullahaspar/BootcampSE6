using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.DTOs;

namespace MyAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
//localhost:port/api/Category
public class CategoryController : ControllerBase
{
	private readonly MyDb _db;
	public CategoryController(MyDb database) 
	{
		_db = database;
	}
	
	[HttpGet]
	//GET : localhost:port/api/category/asdasdasdasd?
	public IActionResult GetAllCategory([FromQuery] bool orderByName=false, [FromQuery] bool isAscending =true) 
	{
		List<CategoryDTO> myList = new();
		List<Category> myCategory = _db.Categories.ToList();
		
		foreach(var c in myCategory) 
		{
			myList.Add(new CategoryDTO()
			{
				Id = c.CategoryId,
				Name = c.CategoryName,
				Description = c.Description
			});
		}
		if(orderByName == false && isAscending == true) 
		{
			return Ok(myList);
		}
  		if (orderByName == true)
		{
			if (isAscending == false)
			{
				return Ok(myList = myList.OrderByDescending(p => p.Name).ToList());
			}
			return Ok(myList = myList.OrderBy(p => p.Name).ToList());
		}
		return Ok(myList = myList.OrderByDescending(p => p.Id).ToList());
		
	}
	
	[HttpGet]
	[Route("{id:int}")]
	//GET : localhost:port/api/category/{id}
	public IActionResult GetCategoryById([FromRoute] int id) 
	{
		var category = _db.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryId == id);
		if(category is null) 
		{
			return NotFound("Category not found");
		}
		return Ok(category);
	}
	
	[HttpGet]
	[Route("name")]
	//GET : localhost:port/api/category/name
	public IActionResult GetCategoryName() 
	{
		IQueryable<string>? category = _db.Categories.Include(c => c.Products).Select(c => c.CategoryName);
		if(category is null) 
		{
			return NotFound("Category not found");
		}
		return Ok(category);
	}
	
	[HttpPost]
	//POST : localhost:port/api/category
	//Request Body : CategoryDTO
	public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO inputcategory)  
	{
		var category = new Category()
		{
			CategoryName = inputcategory.Name,
			Description = inputcategory.Description
		};
		await _db.Categories.AddAsync(category);
		int result = await _db.SaveChangesAsync();
		if (result > 0 ) 
		{
			return Ok("Succeed");
		} 
		return BadRequest("Failed. Category already created before");
	}
	
	[HttpPut]
	[Route("{id:int}")]
	//PUT : localhost:port/api/category/{id}
	//Request Body : CategoryDTO
	public async Task<IActionResult> ChangeCategory([FromRoute] int id, 
													[FromBody] CategoryDTO category) 
	{
		Category? resultCategory = await _db.Categories.FindAsync(id);
		if(category is null) 
		{
			return NotFound("Category is not available");
		}
		resultCategory.CategoryName = category.Name;
		resultCategory.Description = category.Description;
		await _db.SaveChangesAsync();
		return Ok(resultCategory);
	}
	
	[HttpDelete]
	[Route("{id:int}")]
	//DELETE : localhost:port/api/category/{id}
	public async Task<IActionResult> DeleteCategory([FromRoute] int id) 
	{
		var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
		if(category is null) 
		{
			return NotFound();
		}
		_db.Categories.Remove(category);
		await _db.SaveChangesAsync();
		return Ok();
	}
}
