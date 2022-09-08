using CodeMaze.Entities;
using CodeMaze.GraphQL.GraphQLTypes;
using CodeMaze.Services;
using GraphQL;
using GraphQL.Types;

namespace CodeMaze.GraphQL.GraphQLQueries;

public class AppMutation : ObjectGraphType
{
    public AppMutation(IOwnerService ownerService)
    {
        Field<OwnerType>(
            "createOwner",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" }),
            resolve: context =>
            {
                var owner = context.GetArgument<Owner>("owner");
                return ownerService.CreateOwner(owner);
            });
    }
}
