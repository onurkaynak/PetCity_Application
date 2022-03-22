public interface IBrandRepository{
    Task<Brand> AddBrandAsync(Brand brand);
    Task<Brand> UpdateBrandAsync(Brand brand);
    Task DeleteBrandAsync(Brand brand);
    Task<List<Brand>> GetAllBrandAsync();
    Task<Brand> GetByBrandIdAsync(int brandId);
    Task<List<Brand>> GetAllBrandByNameAsync(string brandName);
    

}