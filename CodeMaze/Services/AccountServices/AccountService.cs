using CodeMaze.Entities;
using CodeMaze.Entities.Context;


namespace CodeMaze.Services;

public class AccountService : IAccountService
{
    private readonly ApplicationContext _context;

    public AccountService(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Account> GetAll() => _context.Accounts.ToList();
    
}