public class User
{
public int? Id { get; set; }
public string? Name { get; set; }
public virtual List<Incidence>? IncidenceList { get; set; }
}