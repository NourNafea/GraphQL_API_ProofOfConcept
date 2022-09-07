using CodeMaze.GraphQL.GraphQLQueries;
using GraphQL.Types;


namespace CodeMaze.GraphQL.GraphQLSchema;
//inherit from the Schema class which resides in the GraphQL.Types namespace.
public class AppSchema : Schema
{
    //inject the IServiceProvider which is going to help us provide our Query, Mutation, or Subscription objects.
    public AppSchema(IServiceProvider provider) 
        : base(provider)
    {
        Query = provider.GetRequiredService<AppQuery>();
    }
}