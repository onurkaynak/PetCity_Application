    public interface ICompanyRepository{
    Task<Company> AddCompanyAsync(Company company);
    Task<Company> UpdateCompanyAsync(Company company);
    Task DeleteCompanyAsync(Company company);
    Task<List<Company>> GetAllCompanyAsync();
    Task<Company> GetCompanyByIdAsync(int companyId);
    Task<Company> GetCompanyByNameAsync(string companyName);
    
    }