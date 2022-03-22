
public class SupplierAddressDTO
{
    public string Name { get; set; }
    public string OpenAddress1 { get; set; }
    public string OpenAddress2 { get; set; }
    public int? CountryCode { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string District { get; set; }

    public SupplierAddressDTO()
    {
        
    }

    public SupplierAddressDTO(Address address)
    {
        this.Name = address.Name;
        this.OpenAddress1 = address.OpenAddress1;
        this.OpenAddress2 = address.OpenAddress2;
        this.CountryCode = address.Country.Code;
        this.Country = address.Country.Name;
        if( address.State != null)
        {
            this.State = address.State.Name;
        }else{
            this.State = null;
        }        
        this.City = address.City.Name;
        this.District = address.District.Name;
    }

}
