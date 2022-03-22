public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository _brandRepository)
    {
        this._brandRepository = _brandRepository;
    }
    public async Task<Brand> AddBrandAsync(Brand brand)
    {
        await _brandRepository.AddBrandAsync(brand);
        return brand;
    }
    public async Task<Brand> UpdateBrandAsync(int id, Brand brand)
    {
        var updatedBrand = await _brandRepository.GetByBrandIdAsync(id);
        updatedBrand = brand;
        await _brandRepository.UpdateBrandAsync(updatedBrand);
        return brand;

    }
    public async Task DeleteBrandAsync(Brand brand)
    {
        await _brandRepository.DeleteBrandAsync(brand);

    }
    public async Task<List<Brand>> GetAllBrandAsync()
    {
        return await _brandRepository.GetAllBrandAsync();
    }
    public async Task<Brand> GetByBrandIdAsync(int brandId)
    {
        return await _brandRepository.GetByBrandIdAsync(brandId);
    }
    public async Task<List<Brand>> GetAllBrandByNameAsync(string brandName)
    {
        return await _brandRepository.GetAllBrandByNameAsync(brandName);
    }
}