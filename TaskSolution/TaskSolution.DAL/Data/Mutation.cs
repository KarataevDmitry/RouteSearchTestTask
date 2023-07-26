using HotChocolate;

using Microsoft.EntityFrameworkCore;

using TaskSolution.DAL.Models;

namespace TaskSolution.DAL.Data;
public class Mutation
{
    public async Task<TravelRoute> AddTravelRoute([Service] ApplicationDbContext dbContext,
                                               string startPointName,
                                               string endPointName,
                                               DateTime startDateTimeUTC,
                                               DateTime arrivalDateTimeUTC,
                                               TimeSpan timeToLive,
                                               int cost)
    {
        var travelRoute = new TravelRoute()
        {
            StartPoint = startPointName,
            EndPoint = endPointName,
            ArrivalDateTimeUTC = arrivalDateTimeUTC,
            StartDateTimeUTC = startDateTimeUTC,
            Cost = cost,
            TimeToLive = timeToLive
        };
        await dbContext.TravelRoutes.AddAsync(travelRoute);
        await dbContext.SaveChangesAsync();
        return travelRoute;
    }
}