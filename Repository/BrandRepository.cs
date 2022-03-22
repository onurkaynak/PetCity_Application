public class BrandRepository : IBrandRepository{

    private readonly PetCityContext _context;

    public BrandRepository(PetCityContext context)
    {
        _context = context;
        
    }
    public async Task<Brand> AddBrandAsync(Brand brand)
    {
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();
        return brand;
    }
    public async Task<Brand> UpdateBrandAsync(Brand brand)
    {
        _context.Brands.Update(brand);
        await _context.SaveChangesAsync();
        return brand;

    }
    public async Task DeleteBrandAsync(Brand brand)
    {
         _context.Brands.Remove(brand);
         await _context.SaveChangesAsync();
    }
    public async Task<List<Brand>> GetAllBrandAsync()
    {
        return await _context.Brands.ToListAsync();
    }
    public async Task<Brand> GetByBrandIdAsync(int brandId)
    {
        return await _context.Brands.FirstOrDefaultAsync(p=> p.Id == brandId);
    }
    public async Task<List<Brand>> GetAllBrandByNameAsync(string brandName)
    {
        return await _context.Brands.Where(p=> p.Name == brandName).ToListAsync();

    }

}