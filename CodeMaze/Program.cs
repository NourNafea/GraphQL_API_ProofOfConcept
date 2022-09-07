using CodeMaze.Entities.Context;
using CodeMaze.GraphQL.GraphQLSchema;
using CodeMaze.Services;
using GraphQL.Server;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
//register GraphQL

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(x => x.UseNpgsql(connectionString));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//register services
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IAccountService, AccountService>();


builder.Services.AddScoped<AppSchema>();
builder.Services.AddGraphQL(options =>
    {
        
    })
    .AddSystemTextJson()
    .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // add altair UI to development only
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<AppSchema>();
app.UseGraphQLPlayground(options: new GraphQL.Server.Ui.Playground.PlaygroundOptions());

app.Run();