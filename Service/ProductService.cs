public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> AddProduct(Product product)
    {
        return await _productRepository.AddProduct(product);
    }

    public async Task DeleteProduct(Product product)
    {
        await _productRepository.DeleteProduct(product);
    }

    public async Task<List<Product>> GetAllProduct()
    {
        return await _productRepository.GetAllProduct();
    }

    public async Task<List<Product>> GetAllProductByBrandId(int brandId)
    {
        return await _productRepository.GetAllProductByBrandId(brandId);
    }

    public async Task<List<Product>> GetAllProductByCategoryId(int categoryId)
    {
        return await _productRepository.GetAllProductByCategoryId(categoryId);
    }

    public async Task<List<Product>> GetAllProductByName(string productName)
    {
        return await _productRepository.GetAllProductByName(productName);
    }

    public async Task<List<Product>> GetAllProductByPriceASC(int price)
    {
        return await _productRepository.GetAllProductByPriceASC(price);
    }

    public async Task<List<Product>> GetAllProductByPriceDESC(int price)
    {
        return await _productRepository.GetAllProductByPriceDESC(price);
    }

    public async Task<List<Product>> GetAllProductByPriceRange(int minPrice, int maxPrice)
    {
        return await _productRepository.GetAllProductByPriceRange(minPrice,maxPrice);
    }

    public async Task<Product> GetByProductId(int productId)
    {
        return await _productRepository.GetByProductId(productId);
    }

    public async Task<Product> UpdateProduct(int id, Product product)
    {
        var updatedProduct = await _productRepository.GetByProductId(id);
        updatedProduct = product;
        await _productRepository.UpdateProduct(product);
        return product;
    }
}