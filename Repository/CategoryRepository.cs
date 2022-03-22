public class CategoryRepository : ICategoryRepository
{
    private readonly PetCityContext _context;

    public CategoryRepository(PetCityContext context)
    {
        _context = context;
    }

    public async Task<Category> AddCategory(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task DeleteCategory(Category category)
    {
        _context.Categories.Remove(category);
         await _context.SaveChangesAsync();
        
    }

    public async Task<List<Category>> GetAllCategory()
    {
       return await _context.Categories.ToListAsync();
    }

    public async Task<List<Category>> GetAllCategoryByName(string categoryName)
    {
        return await _context.Categories.Where(c => c.Name == categoryName).ToListAsync();
    }

    public async Task<Category> GetByCategoryId(int categoryId)
    {
        return await _context.Categories.FirstOrDefaultAsync(c=>c.Id == categoryId);
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return category;

    }
}