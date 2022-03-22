public class CategoryService : ICategoryService{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> AddCategory(Category category)
    {
        await _categoryRepository.AddCategory(category);
        return category;
    }

    public async Task<Category> UpdateCategory(int id, Category category)
    {
        var updatedCategory = await _categoryRepository.GetByCategoryId(id);
        updatedCategory = category;
        await _categoryRepository.UpdateCategory(updatedCategory);
        return category;
    }

    public async Task DeleteCategory(Category category)
    {
        await _categoryRepository.DeleteCategory(category);
    }

    public async Task<List<Category>> GetAllCategory()
    {
       return await _categoryRepository.GetAllCategory();
    }

    public async Task<Category> GetByCategoryId(int categoryId)
    {
        return await _categoryRepository.GetByCategoryId(categoryId);
    }

    public async Task<List<Category>> GetAllCategoryByName(string categoryName)
    {
        return await _categoryRepository.GetAllCategoryByName(categoryName);
    }

}