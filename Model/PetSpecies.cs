public class PetSpecies{
    public int Id { get; set; }
    public string? Name { get; set; }
    [ForeignKey("Id")]
    public virtual IEnumerable<PetSubSpecies>? SubSpecies { get; set; }


}