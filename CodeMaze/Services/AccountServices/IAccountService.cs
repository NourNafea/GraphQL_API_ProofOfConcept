using CodeMaze.Entities;

namespace CodeMaze.Services;

public interface IAccountService
{
    IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId);
    //add dataloader
    Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds);
}
