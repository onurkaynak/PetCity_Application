public class CompanyRepository : ICompanyRepository {

    private readonly PetCityContext _context;

    public CompanyRepository(PetCityContext context)
    {
        _context = context;
    }

    public async Task <Company> AddCompanyAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
        return company;

    }
    public async Task <Company> UpdateCompanyAsync(Company company)
    {
         _context.Companies.Update(company);
         await _context.SaveChangesAsync();
         return company;
    }
    public async Task DeleteCompanyAsync(Company company)
    {
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
    }
    public async Task <List<Company>> GetAllCompanyAsync()
    {
        return await _context.Companies.ToListAsync();
    }
    public async Task <Company> GetCompanyByIdAsync(int companyId)
    {
         return await _context.Companies.FirstOrDefaultAsync(p=> p.Id == companyId);
    }
    public async Task <Company> GetCompanyByNameAsync(string companyName)
    {
        return await _context.Companies.FirstOrDefaultAsync(P=> P.Name == companyName);
               
    }

}