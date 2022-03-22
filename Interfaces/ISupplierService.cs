using Microsoft.AspNetCore.Mvc;

public interface ISupplierService
{
    Task<IEnumerable<SupplierDTO>> GetAllSupplier();
    Task<SupplierDTO> GetSupplierById(int id);
    Task<SupplierDTO> GetSupplierByName(string Name);
    Task<SupplierDTO> GetSupplierByEmail(string email);

    Task<IEnumerable<SupplierDTO>> GetSupplierByRating(string Rating);
    Task<IEnumerable<SupplierDTO>> GetSupplierByMinRatingAndAbove(string MinRating);
    Task<IEnumerable<SupplierDTO>> GetSupplierByRatingRange(string DownRating,string UpRating);

    IEnumerable<SupplierDTO> SupplierToSupplierDTO(IEnumerable<Supplier> suppliers);

    Task<SupplierDTO> CreateSupplierOperation(Supplier supplier);
    Task<SupplierDTO> UpdateSupplierOperation(int id, Supplier supplier);
    Task<SupplierDTO> DeleteSupplierOperation(int id);

}