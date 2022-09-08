using CodeMaze.Entities;
using CodeMaze.Entities.Context;

namespace CodeMaze.Services;

public class OwnerService : IOwnerService
{
    private readonly ApplicationContext _context;

    public OwnerService(ApplicationContext context)
    {
        _context = context;
    }
    
    //Arrow function
    public IEnumerable<Owner> GetAll() => _context.Owners.ToList();
    
    public Owner GetById(Guid id) => _context.Owners.SingleOrDefault(o => o.Id.Equals(id));
}