using CodeMaze.GraphQL.GraphQLTypes;
using CodeMaze.Services;
using GraphQL.Types;

namespace CodeMaze.GraphQL.GraphQLQueries;
//this class inherits from the ObjectGraphType as well, just the non-generic one.
//Moreover, we inject our repository object inside a constructor and create a field to return the result for the specific query.
public class AppQuery : ObjectGraphType
{
    public AppQuery(IOwnerService ownerService)
    {
        Field<ListGraphType<OwnerType>>(
            "owners",
            resolve: context => ownerService.GetAll()
        );
        
    }
}