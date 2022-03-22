public class CompanyService{

private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository _companyRepository)
    {
        this._companyRepository = _companyRepository;
    }
    public async Task<Company> AddCompanyAsync(Company company)
    {
        await _companyRepository.AddCompanyAsync(company);
        return company;
    }
    public async Task<Company> UpdateCompanyAsync(int id, Company company)
    {
        var updatedCompany = await _companyRepository.GetCompanyByIdAsync(id);
        updatedCompany = company;
        await _companyRepository.UpdateCompanyAsync(updatedCompany);
        return company;

    }
    public async Task DeleteCompanyAsync(Company company)
    {
        await _companyRepository.DeleteCompanyAsync(company);

    }
    public async Task<List<Company>> GetAllCompanyAsync()
    {
        return await _companyRepository.GetAllCompanyAsync();
    }
    public async Task<Company> GetByCompanyIdAsync(int companyId)
    {
        return await _companyRepository.GetCompanyByIdAsync(companyId);
    }
    public async Task<Company> GetByCompanyNameAsync(string companyName)
    {
        return await _companyRepository.GetCompanyByNameAsync(companyName);
    }
    
}