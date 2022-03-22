public class Pet{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? PetImageUrl { get; set; }
    public PetGender Gender{get; set;}
    public PetSpecies? Species { get; set; }
    public PetSubSpecies? SubSpecies { get; set; }
    public PetHealthStatus? HealthStatus { get; set; }
}