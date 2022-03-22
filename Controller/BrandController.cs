using Microsoft.AspNetCore.Mvc;
namespace PetCity.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpPost]
    public async Task<Brand> Add(Brand brand)
    {
        return await _brandService.AddBrandAsync(brand);
        
    }
    [HttpPut("update")]
    public async Task<Brand> Update(int id, Brand brand)
    {
        return await _brandService.UpdateBrandAsync(id,brand);
    }
    [HttpDelete]
    public async Task Delete(Brand brand)
    {
        await _brandService.DeleteBrandAsync(brand);
    }
    [HttpGet("getall")]
    public async Task<List<Brand>> GetAll()
    {
        return await _brandService.GetAllBrandAsync();
    }
    [HttpGet("getbyid")]
    public async Task<Brand> GetByBrandId([FromQuery]int brandId)
    {
        return await _brandService.GetByBrandIdAsync(brandId);
    }
    [HttpGet]
    public async Task<List<Brand>> GetAllBrandByName([FromQuery]string brandName)
    {
        return await _brandService.GetAllBrandByNameAsync(brandName);
    }






}