using CodeMaze.Entities;
using CodeMaze.Services;
using GraphQL.Types;

namespace CodeMaze.GraphQL.GraphQLTypes;
//each of the schema properties (Query, Mutation, or Subscription) implements IObjectGraphType which means that the objects we are going to resolve must implement the same type as well.
//This also means that our GraphQL API can’t return our models directly as a result but GraphQL types that implement IObjectGraphType instead.
public class OwnerType : ObjectGraphType<Owner>
{
    public OwnerType(IAccountService accountService)
    {
        Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
        Field(x => x.Name).Description("Name property from the owner object.");
        Field(x => x.Address).Description("Address property from the owner object.");
        Field<ListGraphType<AccountType>>(
            "accounts",
            resolve: context => accountService.GetAllAccountsPerOwner(context.Source.Id)
        );
    }
}