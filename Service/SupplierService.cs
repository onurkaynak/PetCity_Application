using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

public class SupplierService : ISupplierService
{

    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<SupplierDTO> GetSupplierByEmail(string email)
    {
        try
        {
            SupplierDTO supplierDTO = new SupplierDTO(await _supplierRepository.GetSupplierByEmail(email));
            if (supplierDTO != null)
            {
                return supplierDTO;
            }
            return new SupplierDTO();
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();
        }


    }

    public async Task<IEnumerable<SupplierDTO>> GetSupplierByMinRatingAndAbove(string MinRating)
    {
        try
        {
            double minrating = 0;
            var min = double.TryParse(MinRating, out minrating);
            if (!min)
            {
                throw new NotImplementedException();
            }
            return SupplierToSupplierDTO(await _supplierRepository.GetSupplierByMinRatingAndAbove(minrating));
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();
        }

    }

    public async Task<IEnumerable<SupplierDTO>> GetSupplierByRating(string Rating)
    {
        try
        {
            double _rating = 0;
            var min = double.TryParse(Rating, out _rating);
            if (!min)
            {
                throw new NotImplementedException();
            }
            return SupplierToSupplierDTO(await _supplierRepository.GetSupplierByRating(_rating));
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();
        }
    }

    public async Task<IEnumerable<SupplierDTO>> GetSupplierByRatingRange(string DownRating, string UpRating)
    {
        try
        {
            double down_rating = 0, up_rating = 0;
            var down = double.TryParse(DownRating, out down_rating);
            var up = double.TryParse(UpRating, out up_rating);
            if (!down || !up)
            {
                throw new NotImplementedException();
            }

            return SupplierToSupplierDTO(await _supplierRepository.GetSupplierByRatingRange(down_rating, up_rating));
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();
        }

    }

    async Task<SupplierDTO> ISupplierService.CreateSupplierOperation(Supplier supplier)
    {
        try
        {
            Supplier supplierResponse = await _supplierRepository.GetSupplierByName(supplier.Name);
            if (supplierResponse == null)
            {
                return new SupplierDTO(await _supplierRepository.CreateSupplierOperation(supplier));
            }
            return new SupplierDTO();
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();
        }
    }

    async Task<SupplierDTO> ISupplierService.DeleteSupplierOperation(int id)
    {
        try
        {
            SupplierDTO supplierDTO = new SupplierDTO(await _supplierRepository.GetSupplierById(id));
            if (supplierDTO != null)
            {
                return new SupplierDTO(await _supplierRepository.ChangeSupplierVisibility(id));
            }
            return new SupplierDTO();
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();
        }

    }

    async Task<IEnumerable<SupplierDTO>> ISupplierService.GetAllSupplier()
    {
        try
        {
            IEnumerable<SupplierDTO> supplierDTOs = SupplierToSupplierDTO(await _supplierRepository.GetAllSupplier());
            if (supplierDTOs != null)
            {
                return supplierDTOs;
            }
            return new List<SupplierDTO> { new SupplierDTO() };
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();
        }

    }

    async Task<SupplierDTO> ISupplierService.GetSupplierById(int id)
    {
        try
        {
            SupplierDTO supplierDTO = new SupplierDTO(await _supplierRepository.GetSupplierById(id));
            if (supplierDTO != null)
            {
                return supplierDTO;
            }
            return new SupplierDTO();
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();
        }

    }

    async Task<SupplierDTO> ISupplierService.GetSupplierByName(string Name)
    {
        try
        {
            string name = "";
            string[] temp = Name.Split('-');
            for (int i = 0; i < temp.Length; i++)
            {
                name += temp[i];
                if (i < temp.Length - 1)
                    name += " ";
            }

            SupplierDTO supplierDTO = new SupplierDTO(await _supplierRepository.GetSupplierByName(name));
            if (supplierDTO != null)
            {
                return supplierDTO;
            }
            return new SupplierDTO();
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();
        }

    }

    async Task<SupplierDTO> ISupplierService.UpdateSupplierOperation(int id, Supplier supplier)
    {
        try
        {
            SupplierDTO supplierDTO = new SupplierDTO(await _supplierRepository.GetSupplierById(id));
            if (supplierDTO != null)
            {
                return new SupplierDTO(await _supplierRepository.UpdateSupplierOperation(id, supplier));
            }
            return new SupplierDTO();
        }
        catch (Exception ex)
        {            
            throw new NotImplementedException();
        }

    }


    public IEnumerable<SupplierDTO> SupplierToSupplierDTO(IEnumerable<Supplier> suppliers)
    {   //TODO degisecek
        List<SupplierDTO> supplierDTOs = new List<SupplierDTO>();
        foreach (Supplier item in suppliers)
        {
            supplierDTOs.Add(new SupplierDTO(item));
        }
        return supplierDTOs;
    }

}