using TaskSolution.DTO;
namespace TaskSolution.API.Services
public class RoutesService : IRouteService
{
    public TravelRouteDTO GetRouteByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }
    public IEnumerable<TravelRouteDTO> GetRoutes() 
    { 
        throw new NotImplementedException(); 
    }

    TravelRouteDTO IRouteService.GetRouteByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }
}