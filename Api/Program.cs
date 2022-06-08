using Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddSingleton<Repository>()
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();




var app = builder.Build();

app.MapGraphQL("/");


app.Run();
