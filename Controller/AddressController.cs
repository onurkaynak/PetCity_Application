using Microsoft.AspNetCore.Mvc;
namespace PetCity.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _IAddressService;

    public AddressController(IAddressService addressService)
    {
        _IAddressService = addressService;

    }

    [HttpGet]
    public async Task<List<Address>> GetAllAddresses()
    {
        return await _IAddressService.GetAllAddresses();
    }



    [HttpGet("GetAddressById")]
    public async Task<Address> GetAddress([FromQuery] int id)
    {
        return await _IAddressService.GetAddress(id);
    }

    [HttpGet("CountryList")]
    public async Task<ActionResult<List<Country>>> GetAllCountries()

    {
        return await _IAddressService.GetAllCountries();
    }


    [HttpGet("GetAllStatesByCountryId")]
    public async Task<List<State>> GetAllStatesByCountryId([FromQuery] int id)
    {
        return await _IAddressService.GetAllStatesByCountryId(id);
    }

    ///http://localhost:5281/Address/GetAllCitiesByStateId?id=3 şeklinde sorgulamalar yapılacak
    [HttpGet("GetAllCitiesByStateId")]
    public async Task<List<City>> GetAllCitiesByStateId([FromQuery] int id)
    {
        return await _IAddressService.GetAllCitiesByStateId(id);
    }

    [HttpGet("GetAllCitiesByContryId")]
    public async Task<List<City>> GetAllCitiesByContryId([FromQuery] int id)
    {
        return await _IAddressService.GetAllCitiesByContryId(id);
    }

    [HttpGet("GetAllDistrictsCityById")]
    public async Task<List<District>> GetAllDistrictsCityById([FromQuery] int id)
    {
        return await _IAddressService.GetAllDistrictsByCityId(id);
    }

    [HttpPost]
    public async Task<Address> RegisterAddress(Address address)
    {
        return await _IAddressService.RegisterAddress(address);
    }

    [HttpDelete("DeleteAddress")]
    public async Task<Address> DeleteAddress([FromQuery] int id)
    {
        return await _IAddressService.DeleteAddress(id);
    }


    [HttpPut("UpdateAddress")]
    public async Task<Address> UpdateAddress([FromQuery] int id)
    {
        return await _IAddressService.UpdateAddress(id);
    }


    [HttpPost("CreateCountry")]
    public async Task<Country> CreateCountry(Country country)
    {


        return await _IAddressService.CreateCountry(country);

    }
    [HttpPost("CreateCity")]
    public async Task<City> CreateCity(City city)
    {


        return await _IAddressService.CreateCity(city);

    }
    [HttpPost("CreateState")]
    public async Task<State> CreateState(State state)
    {


        return await _IAddressService.CreateState(state);

    }
[HttpPost("CreateDistrict")]
    public async Task<District> CreateDistrict(District district)
    {


        return await _IAddressService.CreateDistrict(district);

    }

    [HttpDelete("DeleteCountry")]
    public async Task<Country> DeleteCountry(Country country)
    {


        return await _IAddressService.DeleteCountry(country);

    }


    [HttpDelete("DeleteCity")]
    public async Task<City> DeleteCity(City city)
    {


        return await _IAddressService.DeleteCity(city);

    }

    [HttpDelete("DeleteState")]
    public async Task<State> DeleteState(State state)
    {


        return await _IAddressService.DeleteState(state);

    }
    [HttpDelete("DeleteDistrict")]
    public async Task<District> DeleteDistrict(District district)
    {


        return await _IAddressService.DeleteDistrict(district);

    }

}