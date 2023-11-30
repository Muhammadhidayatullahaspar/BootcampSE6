using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;

namespace MyWeb.Controllers;

public class CategoryController : Controller
{
	private readonly MyDb _db;
	public CategoryController(MyDb db)
	{
			_db = db;
		
	}
	
	public async Task<IActionResult> Index() 
	{
		List<Category> category = await _db.Categories.ToListAsync();
		return View(category);
	}
	public IActionResult Create() 
	{
		return View();
	}
	
	[HttpPost]
	public async Task<IActionResult> Create(Category category) 
	{
		await _db.Categories.AddAsync(category);
		await _db.SaveChangesAsync();
		return RedirectToAction("Index", "Category");
	}
	
	public async Task<IActionResult> Edit(int? id) 
	{
		var category = await _db.Categories.FindAsync(id);
		if(category is null) 
		{
			return NotFound();
		}
		return View(@"Views/Category/Edit/Edit.cshtml",category);
	}
		
	[HttpPost]
	public async Task<IActionResult> Edit(Category category) 
	{
		_db.Categories.Update(category);
		await _db.SaveChangesAsync();
		return RedirectToAction("Index");
	}
}
