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
    
    public Owner CreateOwner(Owner owner)
    {
        owner.Id = Guid.NewGuid();
        _context.Owners.Add(owner);
        _context.SaveChanges();
        return owner;
    }

    public Owner UpdateOwner(Owner dbOwner, Owner owner)
    {
        dbOwner.Name = owner.Name;
        dbOwner.Address = owner.Address;
        _context.SaveChanges();
        return dbOwner;
    }
    
    public void DeleteOwner(Owner owner)
    { 
        _context.Remove(owner);
        _context.SaveChanges();
    }
}