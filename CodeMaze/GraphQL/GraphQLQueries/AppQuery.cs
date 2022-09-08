using CodeMaze.GraphQL.GraphQLTypes;
using CodeMaze.Services;
using GraphQL;
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
        
        //GET OWNER BY ID
        Field<OwnerType>(
            "owner",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
            resolve: context =>
            {
                Guid id;
                if (!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
                {
                    context.Errors.Add(new ExecutionError("Wrong value for guid"));
                    return null;
                }
                return ownerService.GetById(id);
            }
        );
    }
}