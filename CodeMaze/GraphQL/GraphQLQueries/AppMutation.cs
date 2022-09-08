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
            }
        );
        
        Field<OwnerType>(
            "updateOwner",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" }, 
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
            resolve: context =>
            {
                var owner = context.GetArgument<Owner>("owner");
                var ownerId = context.GetArgument<Guid>("ownerId");
                var dbOwner = ownerService.GetById(ownerId);
                if (dbOwner == null)
                {
                    context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                    return null;
                }
                return ownerService.UpdateOwner(dbOwner, owner);
            }
        );
        
        Field<StringGraphType>(
            "deleteOwner",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
            resolve: context =>
            {
                var ownerId = context.GetArgument<Guid>("ownerId");
                var owner = ownerService.GetById(ownerId);
                if (owner == null)
                {
                    context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                    return null;
                }
                ownerService.DeleteOwner(owner);
                return $"The owner with the id: {ownerId} has been successfully deleted from db.";
            }
        );
        
    }
}
