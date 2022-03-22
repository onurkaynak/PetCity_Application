public class Account
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsBlocked { get; set; }
    public bool Visibility { get; set; }
    public virtual ICollection<Role>? Role { get; set; }


    public virtual ICollection<Supplier> Suppliers { get; set; }        

    public Account()
    {
        Suppliers = new List<Supplier>();
    }

    public Account(AccountDTO incomingAccount) {
        this.Email = incomingAccount.Email;
        this.Password = incomingAccount.Password;
    }


    public Account(int id, string email, string password, bool isblocked, bool visibility)
    {
        this.Id = id;
        this.Email = email;
        this.Password = password;
        this.IsBlocked = isblocked;
        this.Visibility = visibility;
    }
}
