using CodeMaze.Entities;
using GraphQL.Types;

namespace CodeMaze.GraphQL.GraphQLTypes;

public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
{
    public AccountTypeEnumType()
    {
        Name = "Type";
        Description = "Enumeration for the account type object.";
    }
}