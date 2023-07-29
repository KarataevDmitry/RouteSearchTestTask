
using Asp.Versioning;

using Microsoft.EntityFrameworkCore;

using System.Reflection.Metadata.Ecma335;

using TaskSolution.DAL.Data;
using TaskSolution.DAL.Interfaces;
using TaskSolution.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(opt => {
    opt.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    opt.ApiVersionReader = new QueryStringApiVersionReader("v");
});
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddScoped<ITravelRouteRepository, TravelRouteRepository>();
//builder.Services.AddScoped<ITravelPointRepository, TravelRouteRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => 
    options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>().AddProjections().AddFiltering().AddSorting()
    .AddMutationType<Mutation>();
builder.WebHost.UseUrls("http://localhost:4883");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGraphQL("/graphql");
app.MapGet("/ping", () => Results.Ok());
app.Run();

/// <summary>
/// This added for only for testing purposes
/// </summary>
public partial class Program
{

}