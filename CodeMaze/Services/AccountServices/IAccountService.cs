using CodeMaze.Entities;

namespace CodeMaze.Services;

public interface IAccountService
{
    IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId);
}