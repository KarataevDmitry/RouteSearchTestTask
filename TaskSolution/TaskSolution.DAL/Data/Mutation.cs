using HotChocolate;

using Microsoft.EntityFrameworkCore;

using TaskSolution.DAL.Models;

namespace TaskSolution.DAL.Data;
public class Mutation
{
    public async Task<TravelPoint> TravelPoint([Service] ApplicationDbContext dbContext, string name)
    {
        var travelPoint = new TravelPoint()
        {
            Name = name
        };
        dbContext.Add(travelPoint);
        await dbContext.SaveChangesAsync();
        return travelPoint;
    }
    public async Task<TravelRoute> TravelRoute([Service] ApplicationDbContext dbContext,
                                               string startPointName,
                                               string endPointName,
                                               DateTime startDateTimeUTC,
                                               DateTime arrivalDateTimeUTC,
                                               TimeSpan timeToLive,
                                               int cost)
    {
        var travelRoute = new TravelRoute()
        {
            ArrivalDateTimeUTC = arrivalDateTimeUTC,
            StartDateTimeUTC = startDateTimeUTC,
            Cost = cost,
            TimeToLive = timeToLive
        };
        var existsStartPoint = await dbContext.TravelPoints.FirstOrDefaultAsync((t) => t.Name == startPointName);
        if (existsStartPoint == null)
        {
            travelRoute.StartPoint = new TravelPoint() { Name = startPointName };
        }
        else { travelRoute.StartPointId = existsStartPoint.Id; }
        var existsEndPoint = await dbContext.TravelPoints.FirstOrDefaultAsync((t) => t.Name ==  endPointName);
        if (existsEndPoint == null)
        {
            travelRoute.EndPoint = new TravelPoint() { Name = endPointName};
        }
        else { travelRoute.EndPointId = existsEndPoint.Id; }
        await dbContext.SaveChangesAsync();
        return dbContext.TravelRoutes.Last();
    }
}