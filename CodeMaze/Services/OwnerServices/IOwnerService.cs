using CodeMaze.Entities;

namespace CodeMaze.Services;

public interface IOwnerService
{
    IEnumerable<Owner> GetAll();
    Owner GetById(Guid id);
}