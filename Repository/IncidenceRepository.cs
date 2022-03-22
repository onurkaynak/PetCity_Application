
public class IncidenceRepository : IIncidenceRepository
{
    private readonly PetCityContext _petCityContext;

    public IncidenceRepository(PetCityContext petCityContext)
    {
        _petCityContext = petCityContext;
    }
    
    public IncidenceRepository(){}

    public async Task<Incidence> ChangeIncidence(IncidenceDTO incidence)
    {
        
             //_petCityContext.Entry(incidence).State = EntityState.Modified;
            Incidence _Incidence = await _petCityContext.Incidences.FindAsync(incidence.Id);
             try
             {
                _Incidence.Name = incidence.Name;
                _Incidence.Description = incidence.Description;
                _Incidence.OpenAddress = incidence.OpenAddress;
                _Incidence.Image = incidence.Image;
                _Incidence.DistrictId = incidence.DistrictId;
                _Incidence.Visibility = incidence.Visibility;
                 _Incidence.Date = incidence.Date;
                await  _petCityContext.SaveChangesAsync();
             }
             catch(Exception ex)
            {
                throw;
            }
            return _Incidence;
    }

    public async Task<Incidence> ChangeIncidenceVisibilityById(int Id)
    {
        var incidence =  await _petCityContext.Incidences.FindAsync(Id); 
        if(incidence == null)
        {
            return null;
        }

        try
        {
            incidence.Visibility=false;
            await _petCityContext.SaveChangesAsync();
            return incidence;
        }
        catch (Exception e)
        { 
            throw;
        }
    }
    
    //todo
    public async Task<Incidence> CreateIncidence(Incidence incidence)
    {
        //var CreatedIncidence = new Incidence(incidence);
        try
        {
            await _petCityContext.Incidences.AddAsync(incidence);
            await _petCityContext.SaveChangesAsync();
            return incidence;
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<Incidence>> GetAllIncidences()
    {
        try{
        IEnumerable<Incidence> Incidences = await (from x in _petCityContext.Incidences  //.Include(i=>i.User).Include(i=>i.District)
                                                   join u in _petCityContext.Users on x.UserId equals u.Id
                                                   join d in _petCityContext.District on x.DistrictId equals d.Id
                                                   select new Incidence()
                                                   {
                                                       Id = x.Id,
                                                       Name = x.Name,
                                                       Date = x.Date,
                                                       Image = x.Image,
                                                       Description = x.Description,
                                                       Visibility = x.Visibility,
                                                       UserId = x.UserId,
                                                       DistrictId = x.DistrictId,
                                                       District = new District()
                                                       {
                                                           Id = x.District.Id,
                                                           Name = x.District.Name,
                                                           City = new City()
                                                           {
                                                               Id = x.District.CityId,
                                                               Name = x.District.City.Name
                                                           }
                                                       },
                                                       OpenAddress = x.OpenAddress,
                                                       User = new User()
                                                       {
                                                           Id = null,
                                                           Name = x.User.Name
                                                       }
                                                   }).ToListAsync();
        return Incidences;
        }
        catch
        {
            throw;
        }
        
    }

    public async Task<IEnumerable<Incidence>> GetIncidencesByUserName(string UserName)
    {
        try{
        //IEnumerable<Incidence> Incidences =  await _petCityContext.Incidences.Where(p=> p.User.Name == UserName).Where(p=>p.Visibility == true).OrderByDescending(p=>p.Date).ToListAsync();
        IEnumerable<Incidence> Incidences = await (from x in _petCityContext.Incidences
                                                   join u in _petCityContext.Users on x.UserId equals u.Id
                                                   join d in _petCityContext.District on x.DistrictId equals d.Id
                                                   where x.User.Name == UserName && x.Visibility == true
                                                   orderby x.Date descending
                                                   select new Incidence()
                                                   {
                                                       Id = x.Id,
                                                       Name = x.Name,
                                                       Date = x.Date,
                                                       Image = x.Image,
                                                       Description = x.Description,
                                                       Visibility = x.Visibility,
                                                       UserId = x.UserId,
                                                       DistrictId = x.DistrictId,
                                                       District = new District()
                                                       {
                                                           Id = x.District.Id,
                                                           Name = x.District.Name,
                                                           City = new City()
                                                           {
                                                               Id = x.District.CityId,
                                                               Name = x.District.City.Name
                                                           }
                                                       },
                                                       OpenAddress = x.OpenAddress,
                                                       User = new User()
                                                       {
                                                           Id = null,
                                                           Name = x.User.Name
                                                       }
                                                   }).ToListAsync();
        return Incidences;
        }
        catch
        {
            throw;
        }
    }
        
    public async Task<IEnumerable<Incidence>> GetIncidencesByDate(DateTime firstDate, DateTime lastDate)
    {
        try{
        var IncidencesByDate = await (from x in _petCityContext.Incidences
                                      join u in _petCityContext.Users on x.UserId equals u.Id
                                      join d in _petCityContext.District on x.DistrictId equals d.Id
                                      where x.Date >= firstDate.Date
                                      && x.Date <= lastDate.Date
                                      && x.Visibility == true
                                      select new Incidence()
                                      {
                                          Id = x.Id,
                                          Name = x.Name,
                                          Date = x.Date,
                                          Image = x.Image,
                                          Description = x.Description,
                                          Visibility = x.Visibility,
                                          UserId = x.UserId,
                                          DistrictId = x.DistrictId,
                                          District = new District()
                                          {
                                              Id = x.District.Id,
                                              Name = x.District.Name,
                                              City = new City()
                                              {
                                                  Id = x.District.CityId,
                                                  Name = x.District.City.Name
                                              }
                                          },
                                          OpenAddress = x.OpenAddress,
                                          User = new User()
                                          {
                                              Id = null,
                                              Name = x.User.Name
                                          }
                                      }).ToListAsync();
        return IncidencesByDate;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Incidence> GetIncidencesById(int Id)
    {
        try{
        //Incidence incidence =  await _petCityContext.Incidences.Where(p=> p.Id == Id).FirstOrDefaultAsync();
        var Incidence = await (from x in _petCityContext.Incidences
                                                   join u in _petCityContext.Users on x.UserId equals u.Id
                                                   join d in _petCityContext.District on x.DistrictId equals d.Id
                                                   where x.Id == Id 
                                                   select new Incidence()
                                                   {
                                                       Id = x.Id,
                                                       Name = x.Name,
                                                       Date = x.Date,
                                                       Image = x.Image,
                                                       Description = x.Description,
                                                       Visibility = x.Visibility,
                                                       UserId = x.UserId,
                                                       DistrictId = x.DistrictId,
                                                       District = new District()
                                                       {
                                                           Id = x.District.Id,
                                                           Name = x.District.Name,
                                                           City = new City()
                                                           {
                                                               Id = x.District.CityId,
                                                               Name = x.District.City.Name
                                                           }
                                                       },
                                                       OpenAddress = x.OpenAddress,
                                                       User = new User()
                                                       {
                                                           Id = null,
                                                           Name = x.User.Name
                                                       }
                                                   }).FirstOrDefaultAsync();
        return Incidence;
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<Incidence>> GetIncidencesByName(string name)
    {
        try{
       //IEnumerable<Incidence> Incidences =  await _petCityContext.Incidences.Where(p=> p.Name == name).Where(p=>p.Visibility == true).OrderByDescending(p=>p.Date).ToListAsync();
       IEnumerable<Incidence> Incidences = await (from x in _petCityContext.Incidences
                                                   join u in _petCityContext.Users on x.UserId equals u.Id
                                                   join d in _petCityContext.District on x.DistrictId equals d.Id
                                                   where x.Name == name && x.Visibility == true
                                                   orderby x.Date descending
                                                   select new Incidence()
                                                   {
                                                       Id = x.Id,
                                                       Name = x.Name,
                                                       Date = x.Date,
                                                       Image = x.Image,
                                                       Description = x.Description,
                                                       Visibility = x.Visibility,
                                                       UserId = x.UserId,
                                                       DistrictId = x.DistrictId,
                                                       District = new District()
                                                       {
                                                           Id = x.District.Id,
                                                           Name = x.District.Name,
                                                           City = new City()
                                                           {
                                                               Id = x.District.CityId,
                                                               Name = x.District.City.Name
                                                           }
                                                       },
                                                       OpenAddress = x.OpenAddress,
                                                       User = new User()
                                                       {
                                                           Id = null,
                                                           Name = x.User.Name
                                                       }
                                                   }).ToListAsync();
        return Incidences; 
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<Incidence>> GetIncidencesByDistrictName(string districtName)
    {
        try{
        //IEnumerable<Incidence> Incidences =  await _petCityContext.Incidences.Where(p=> p.District.Name == districtName).Where(p=>p.Visibility == true).OrderByDescending(p=>p.Date).ToListAsync();
        IEnumerable<Incidence> Incidences = await (from x in _petCityContext.Incidences
                                                   join u in _petCityContext.Users on x.UserId equals u.Id
                                                   join d in _petCityContext.District on x.DistrictId equals d.Id
                                                   where x.District.Name == districtName && x.Visibility == true
                                                   orderby x.Date descending
                                                   select new Incidence()
                                                   {
                                                       Id = x.Id,
                                                       Name = x.Name,
                                                       Date = x.Date,
                                                       Image = x.Image,
                                                       Description = x.Description,
                                                       Visibility = x.Visibility,
                                                       UserId = x.UserId,
                                                       DistrictId = x.DistrictId,
                                                       District = new District()
                                                       {
                                                           Id = x.District.Id,
                                                           Name = x.District.Name,
                                                           City = new City()
                                                           {
                                                               Id = x.District.CityId,
                                                               Name = x.District.City.Name
                                                           }
                                                       },
                                                       OpenAddress = x.OpenAddress,
                                                       User = new User()
                                                       {
                                                           Id = null,
                                                           Name = x.User.Name
                                                       }
                                                   }).ToListAsync();
        return Incidences;
        }
        catch
        {
            throw;
        }
    }



    private bool IncidenceExists(int id)
    {
        return _petCityContext.Incidences.Any(e => e.Id == id);
    }

    
}