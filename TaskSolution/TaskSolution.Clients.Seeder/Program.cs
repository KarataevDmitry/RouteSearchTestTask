


using System.Runtime.CompilerServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddProviderOneClient(StrawberryShake.ExecutionStrategy.CacheFirst)
    //.ConfigureHttpClient(_ => _.BaseAddress = new Uri("http://localhost:5000/graphql"));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//async Task CreateRoute([Service] IProviderOneClient client, 
//                                    string startPointName,
//                                               string endPointName,
//                                               DateTime startDateTimeUTC,
//                                               DateTime arrivalDateTimeUTC,
//                                               TimeSpan timeToLive,
//                                               int cost)
//{
//    var tr = await client.CreateTravelRoute.ExecuteAsync(startPointName, endPointName, startDateTimeUTC, arrivalDateTimeUTC, timeToLive, cost);
//}
//var c = app.Services.GetRequiredService<IProviderOneClient>();
//await CreateRoute(c, "Alabama", "New York", new DateTime(2023, 12, 5, 3, 15, 15).ToUniversalTime(), new DateTime(2023, 12, 5, 3, 15, 15).ToUniversalTime(), TimeSpan.FromMinutes(15), 999);
app.Run();

