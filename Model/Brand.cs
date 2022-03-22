public class Brand
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Product>? Products { get; set; }   
    public virtual ICollection<Supplier>? Suppliers { get; set; } 



    public Brand()
    {
        Suppliers = new List<Supplier>();
    }

    public override string ToString()
    {
        var txt = new StringBuilder();
        txt.AppendLine($"Id: {Id}");
        txt.AppendLine($"Brand: {Name}");

        return txt.ToString();
    }
}