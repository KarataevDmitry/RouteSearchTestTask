
using HotChocolate;

using System.Runtime.CompilerServices;

using TaskSolution.Clients.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProviderOneClient(StrawberryShake.ExecutionStrategy.CacheFirst)
    .ConfigureHttpClient(_ => _.BaseAddress = new Uri("http://localhost:5000/graphql"));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

async Task CreateRoute([Service] IProviderOneClient client)
{
    var tr = client.GetTravelRoutes;
}

app.Run();

