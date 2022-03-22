using System.Linq;
using Microsoft.VisualBasic;

public class ProductRepository : IProductRepository
{
    private readonly PetCityContext _context;

    public ProductRepository(PetCityContext context)
    {
        _context=context;
    }
    public async Task<Product> AddProduct(Product product)
    {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
    }

    public async Task DeleteProduct(Product product)
    {
            var result = _context.Remove(product);
            await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllProduct()
    {
        return await _context.Set<Product>().ToListAsync();
    }

    public async Task<List<Product>> GetAllProductByBrandId(int brandId)
    {
        return await _context.Set<Product>().Where(p=> p.BrandId == brandId).ToListAsync();
    }

    public async Task<List<Product>> GetAllProductByCategoryId(int categoryId)
    {
        return await _context.Set<Product>().Where(p=> p.CategoryId == categoryId).ToListAsync();
    }

    public async Task<List<Product>> GetAllProductByName(string productName)
    {
        return await _context.Set<Product>().Where(p=> p.Name == productName).ToListAsync();
    }

    public async Task<List<Product>> GetAllProductByPriceASC(int price)
    {
        return await _context.Set<Product>().OrderBy(p=>p.UnitPrice).ToListAsync();
    }

    public async Task<List<Product>> GetAllProductByPriceDESC(int price)
    {
        return await _context.Set<Product>().OrderByDescending(p=>p.UnitPrice).ToListAsync();
    }

    public async Task<List<Product>> GetAllProductByPriceRange(int minPrice, int maxPrice)
    {
        return await _context.Set<Product>().Where(p=> p.UnitPrice >= minPrice && p.UnitPrice <=maxPrice).ToListAsync();
    }

    public async Task<Product> GetByProductId(int productId)
    {
        return await _context.Set<Product>().SingleOrDefaultAsync(p=> p.Id == productId);
    }

    public async Task<Product> UpdateProduct(Product product)
    {
            var result = _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
    }
}