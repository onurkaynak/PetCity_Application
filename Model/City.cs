public class City{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; } // Normal Foreign Key  -> Shadow Foreign Key
    public Country? Country { get; set; }
    public int? StateId { get; set; }
    public State? State { get; set; }

    public virtual ICollection<Address>? Addresses {get;set;}
    public virtual ICollection<District>? District { get; set; }
}