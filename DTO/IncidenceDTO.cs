public class IncidenceDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual District? District { get; set; }
    public int DistrictId { get; set; }
    public DateTime? Date { get; set; }
    public bool Visibility { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
     public virtual User? User { get; set; }
     public string? OpenAddress { get; set; }
 

    public IncidenceDTO(Incidence incidence)
    {
        Id = incidence.Id;
        Name = incidence.Name;
        District = incidence.District;
        Date = incidence.Date;
        Visibility = incidence.Visibility;
        Image = incidence.Image;
        Description = incidence.Description;
        User = incidence.User;
        DistrictId = incidence.DistrictId;
        OpenAddress = incidence.OpenAddress;
    }
    public IncidenceDTO(){}
}