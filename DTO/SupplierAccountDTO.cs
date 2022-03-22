
public class SupplierAccountDTO
{
    public string Email { get; set; }
    public bool IsBlocked { get; set; }
    public bool Visibility { get; set; }

    public SupplierAccountDTO()
    {
        
    }

    public SupplierAccountDTO(string email, bool isBlocked, bool isVisibility)
    {
        this.Email = email;
        this.IsBlocked = isBlocked;
        this.Visibility = isVisibility;
    }


}