public class PetSubSpecies{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual PetSpecies? Species { get; set; }
}