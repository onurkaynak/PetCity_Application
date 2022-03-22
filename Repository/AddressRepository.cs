
public class AddressRepository : IAddressRepository
{


    PetCityContext _petCityContext;

    public AddressRepository()
    {
        _petCityContext = new PetCityContext();
    }

    async Task<Country> IAddressRepository.FindCountryByName(string countryName)
    {
        return await _petCityContext.Set<Country>().FirstOrDefaultAsync(c => c.Name == countryName);

    }
    async Task<City> IAddressRepository.FindCityByName(string CityName)
    {
        return await _petCityContext.Set<City>().FirstOrDefaultAsync(c => c.Name == CityName);

    }

    async Task<State> IAddressRepository.FindStateByName(string StateName)
    {
        return await _petCityContext.Set<State>().FirstOrDefaultAsync(c => c.Name == StateName);

    }

    async Task<District> IAddressRepository.FindDistrictByName(string DistirctName)
    {
        return await _petCityContext.Set<District>().FirstOrDefaultAsync(c => c.Name == DistirctName);

    }



    public async Task<Address> RegisterAddress(Address address)
    {
        _petCityContext.Address.AddAsync(address);
        _petCityContext.SaveChangesAsync();
        return address;
    }


    public async Task<List<Address>> GetAllAddress()
    {

        return await _petCityContext.Set<Address>().ToListAsync();
    }
    public async Task<Address> GetAddress(int id)
    {

        var getAddress = await _petCityContext.Set<Address>().SingleOrDefaultAsync(p => p.Id == id);

        if (getAddress != null)
        {

            return getAddress;

        }
        else
        {
            return null;
        }
    }
    public async Task<Country> GetCountry(string name)
    {

        var countrycontroller = await _petCityContext.Set<Country>().FirstOrDefaultAsync(p => p.Name == name);
        if (countrycontroller != null)
        {
            return countrycontroller;
        }
        return null;
    }


    public async Task<List<Country>> GetAllCountry()
    {

        return await _petCityContext.Set<Country>().ToListAsync();
    }


    string name;
    public async Task<List<State>> GetAllStatesByCountryId(int id)
    {

        var getState = await _petCityContext.Set<State>().Where(p => p.CountryId == id).ToListAsync();
        if (getState != null)
        {

            return getState;

        }
        else
        {
            return null;
        }
    }

    public async Task<List<City>> GetAllCitiesByStateId(int id)
    {
        var getCity = await _petCityContext.Set<City>().Where(p => p.StateId == id).ToListAsync();
        if (getCity != null)
        {

            return getCity;

        }
        else
        {
            return null;
        }
    }

    public async Task<List<City>> GetAllCitiesByContryId(int id)
    {
        var getCity = await _petCityContext.Set<City>().Where(p => p.CountryId == id).ToListAsync();
        if (getCity != null)
        {

            return getCity;

        }
        else
        {
            return null;
        }
    }

    public async Task<List<District>> GetAllDistrictsByCityId(int id)
    {
        var getDistricts = await _petCityContext.Set<District>().Where(p => p.CityId == id).ToListAsync();
        if (getDistricts != null)
        {

            return getDistricts;

        }
        else
        {
            return null;
        }
    }
    public async Task<Address> DeleteAddress(int id)
    {


        var DeletedAddress = await _petCityContext.Address.FirstOrDefaultAsync(x => x.Id == id);
        _petCityContext.Address.Remove(DeletedAddress);
        _petCityContext.SaveChangesAsync();

        return null;


    }


    Task<Address> IAddressRepository.UpdateAddress(int id)
    {
        throw new NotImplementedException();
    }

    async Task<Country> IAddressRepository.CreateCountry(Country country)
    {

        await _petCityContext.Set<Country>().AddAsync(country);
        await _petCityContext.SaveChangesAsync();
        return country;
    }
    async Task<City> IAddressRepository.CreateCity(City city)
    {
        await _petCityContext.Set<City>().AddAsync(city);
        await _petCityContext.SaveChangesAsync();
        return city;
    }

    async Task<State> IAddressRepository.CreateState(State state)
    {
        await _petCityContext.Set<State>().AddAsync(state);
        await _petCityContext.SaveChangesAsync();
        return state;
    }

    async Task<District> IAddressRepository.CreateDistrict(District district)
    {
        await _petCityContext.Set<District>().AddAsync(district);
        await _petCityContext.SaveChangesAsync();
        return district;
    }

    async Task<Country> IAddressRepository.DeleteCountry(Country country)
    {
        _petCityContext.Set<Country>().Remove(country);
        _petCityContext.SaveChangesAsync();
        return country;
    }

    async Task<City> IAddressRepository.DeleteCity(City city)
    {
        _petCityContext.Set<City>().Remove(city);
        _petCityContext.SaveChangesAsync();
        return city;
    }

    async Task<State> IAddressRepository.DeleteState(State state)
    {
        _petCityContext.Set<State>().Remove(state);
        _petCityContext.SaveChangesAsync();
        return state;
    }

    async Task<District> IAddressRepository.DeleteDistrict(District district)
    {
        _petCityContext.Set<District>().Remove(district);
        _petCityContext.SaveChangesAsync();
        return district;
    }


}
