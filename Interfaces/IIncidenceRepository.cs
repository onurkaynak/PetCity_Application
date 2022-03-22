public interface IIncidenceRepository
{
    Task<IEnumerable<Incidence>> GetAllIncidences();
    Task<IEnumerable<Incidence>> GetIncidencesByDistrictName(string regionName);
    Task<IEnumerable<Incidence>> GetIncidencesByUserName(string username);
    Task<IEnumerable<Incidence>> GetIncidencesByDate(DateTime FirstDate, DateTime LastDate);
    Task<Incidence> GetIncidencesById(int Id);
    Task<IEnumerable<Incidence>> GetIncidencesByName(string name);
    Task<Incidence> ChangeIncidenceVisibilityById(int Id);
    Task<Incidence> CreateIncidence(Incidence incidence);
    Task<Incidence> ChangeIncidence(IncidenceDTO incidence); 
}