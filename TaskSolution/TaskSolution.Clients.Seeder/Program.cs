


using Bogus;

using TaskSolution.Clients.Seeder;

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

//await Seed(new Uri("http://localhost:2292/graphql"));
app.Run();

static async Task CreateRouteInProvider(Uri uri, string startPointName, string endPointName, DateTime startTime, DateTime arrivalTime, TimeSpan timeToLive, int cost)
{
    using var httpClient = new HttpClient() { BaseAddress = uri };
    using var client = new ProviderOneZeroQLClient(httpClient);
    var st = startTime;
    var at = arrivalTime;
    var ttl = timeToLive;
    var c = cost;
    ZeroQL.GraphQLResult<TravelRoute> response = await client.Mutation(o => o.AddTravelRoute<TravelRoute>(
        startPointName: startPointName,
        endPointName: endPointName,
        startDateTimeUTC: st,
        arrivalDateTimeUTC: at,
        timeToLive: ttl,
        cost: c,
        p => new TravelRoute() { Id = p.Id }));
}

static async Task Seed(Uri providerURI)
{
    Console.WriteLine("Seeding started: Provider One");
    for (int i = 0; i < 3000; i++)
    {
        Console.WriteLine("Seed entry");
        var faker = new Faker("en");
        var arrt = faker.Date.Between(new DateTime(2022, 01, 01), new DateTime(2023, 01, 01));
        var stpn = faker.Address.City();
        var epn = faker.Address.City();
        var sd = faker.Date.Between(new DateTime(2022, 01, 01), new DateTime(2023, 01, 01));
        var endd = faker.Date.Between(sd, sd.AddYears(1));
        var ttl = faker.Date.Timespan();
        var cost = faker.Random.Number(500);
        await CreateRouteInProvider(providerURI,stpn, epn, sd, arrt, ttl, cost);
        Console.WriteLine("Seed entry send");
    }
    Console.WriteLine("Seed Provider One Complete");
}