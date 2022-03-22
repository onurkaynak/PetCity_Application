public interface IAccountRepository
{
    Task<List<Account>> GetAllAccounts();
    Task<Account> CreateAccount(Account account);
    Task<Account> GetAccountByEmail(string email);
    Task<Account> UpdateAccountByEmail(string email, Account account);
    Task<Account> UpdateAccountPassword(Account account,string oldpassword, string newpassword); 
    Task<Account> ChangeVisibilityOfAccount();
    Task<Account> BlockAccount();
    Task<Account> Role();
    Task<AccountDTO> CreateAccount(AccountDTO account);   
    Task<Account> FindAccountByEmailAndPasswordAsync(LoginDTO loginDTO);       
    Account FindAccountByEmailAndPassword(LoginDTO loginDTO); 
    
    Task<Account> findAccountByIdAsync(int id);
    Account findAccountById(int id);
}