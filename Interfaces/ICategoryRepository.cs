public interface ICategoryRepository
{
   Task <Category> AddCategory(Category category);
    Task <Category> UpdateCategory(Category category);
    Task DeleteCategory(Category category);
    Task <List<Category>> GetAllCategory();
    Task <Category> GetByCategoryId(int categoryId);
    Task <List<Category>> GetAllCategoryByName(string categoryName);
    
}