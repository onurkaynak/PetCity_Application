
public class Supplier
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public double Rating { get; set; } 
    public bool IsVisibility { get; set; }
    public virtual ICollection<Account>? Account {get; set;}    
    public virtual ICollection<Brand>? Brand { get; set; }
    public int? AddressId { get; set; }
    public virtual Address? Address { get; set; }
     

    

    public Supplier()
    {
         
    }

    public Supplier(Supplier supplier)
    {
        this.Id = supplier.Id;
        this.Name = supplier.Name;
        this.Email = supplier.Email;
        this.Account = supplier.Account;
        this.Address = supplier.Address;
        this.Brand = supplier.Brand;
        this.Rating = supplier.Rating;
        this.IsVisibility = supplier.IsVisibility;
    }

}