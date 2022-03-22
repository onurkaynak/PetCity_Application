using Microsoft.AspNetCore.Mvc;
public class IncidenceService : IIncidenceService
{
    private readonly IIncidenceRepository _IncidenceRepository;
    public IncidenceService(IIncidenceRepository incidenceRepository)
    {
         _IncidenceRepository = incidenceRepository;
    }

    public async Task<IEnumerable<IncidenceDTO>> GetAllIncidences()
    {
        IEnumerable<Incidence> Incidences = await _IncidenceRepository.GetAllIncidences();
        if(Incidences != null)
        {
             return ConvertToIncedenceDTO(Incidences);
        }
        //todo
        return null;

    }

    public async Task<IEnumerable<IncidenceDTO>> GetIncidencesByDistrictName(string districtName)
    {
        IEnumerable<Incidence> Incidences =  await _IncidenceRepository.GetIncidencesByDistrictName(districtName);
        if(Incidences != null)
        {
             return ConvertToIncedenceDTO(Incidences);
        }

        return null;
    }

    public async Task<IEnumerable<IncidenceDTO>> GetIncidencesByUserName(string username)
    {
        IEnumerable<Incidence> Incidences = await _IncidenceRepository.GetIncidencesByUserName(username);
        if(Incidences != null)
        {
             return ConvertToIncedenceDTO(Incidences);
        }
        return null;
    }

    public async Task<IEnumerable<IncidenceDTO>> GetIncidencesByDate(DateTime FirstDate, DateTime LastDate)
    {
        IEnumerable<Incidence> Incidences =  await _IncidenceRepository.GetIncidencesByDate(FirstDate, LastDate);
        if(Incidences != null)
        {
             return ConvertToIncedenceDTO(Incidences);
        }

        return null;
    }

    public async Task<IncidenceDTO> GetIncidencesById(int Id)
    {
       Incidence incidence =  await _IncidenceRepository.GetIncidencesById(Id);
        if(incidence != null)
        {
             return new IncidenceDTO(incidence);
        }

        return null ;
    }

    public async Task<IEnumerable<IncidenceDTO>> GetIncidencesByName(string name)
    {
        IEnumerable<Incidence> Incidences =  await _IncidenceRepository.GetIncidencesByName(name);
        if(Incidences != null)
        {
            return ConvertToIncedenceDTO(Incidences);
        }
        return null;
    }

    public async Task ChangeIncidenceVisibilityById(int Id)
    {
        var incidence = await _IncidenceRepository.GetIncidencesById(Id); 
        if(incidence != null)
        {
            await _IncidenceRepository.ChangeIncidenceVisibilityById(Id);
        }
    }

    public async Task<IncidenceDTO> CreateIncidence(Incidence incidence)
    {
        Incidence Incidence = await _IncidenceRepository.GetIncidencesById(incidence.Id);
        if(incidence == null)
        {
            Incidence _Incidence=  await _IncidenceRepository.CreateIncidence(incidence);
            return new IncidenceDTO(_Incidence);
        }

        return null ;
    }

    public async Task<IncidenceDTO> ChangeIncidence(IncidenceDTO incidence)
    {
        if (incidence != null)
        {
            Incidence Incidence = await _IncidenceRepository.GetIncidencesById(incidence.Id);
            if (Incidence != null)
            {
                Incidence = await _IncidenceRepository.ChangeIncidence(incidence);
                return new IncidenceDTO(Incidence);
            }
        }

        return null ;
    }

    private List<IncidenceDTO> ConvertToIncedenceDTO(IEnumerable<Incidence> Incidences )
    {
        List<IncidenceDTO> IncidenceDTOs = new List<IncidenceDTO>();
        foreach(Incidence incedence in Incidences)
        {
            IncidenceDTOs.Add(new IncidenceDTO(incedence));
        }
        return IncidenceDTOs;
    }
}