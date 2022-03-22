using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpPost("add")]
    public async Task<Category> Add(Category category)
    {
        await _categoryService.AddCategory(category);
        return category;
    }
    [HttpPut("delete")]
    public async Task TaskDelete(Category category)
    {
        await _categoryService.DeleteCategory(category);
        
    }
    [HttpPut("update")]
    public async Task<Category> UpdateCategory(int id, Category category)
    {
        var result = await _categoryService.UpdateCategory(id,category);
        return result;
        
    }

    [HttpGet("getall")]
    public async Task<List<Category>> GetAll()
    {
       return await _categoryService.GetAllCategory(); 
    }
     [HttpGet("getallcategorybyname")]
    public async Task<List<Category>> GetAllCategoryByName(string categoryName)
    {
       return await _categoryService.GetAllCategoryByName(categoryName); 
    }
    [HttpGet("getbycategoryid")]
    public async Task<Category> GetByCategoryId(int categoryId)
    {
       return await _categoryService. GetByCategoryId(categoryId); 
    }
}