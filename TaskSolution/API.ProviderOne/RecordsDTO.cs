namespace TaskSolution.DTO;
public record class TravelPointDTO(string Name);
public record class TravelRouteDTO(TravelPointDTO StartPoint, TravelPointDTO DestinationPoint, DateTime StartTimeUTC, DateTime ArrivalTimeUTC, decimal Cost, DateTime TimeToLive);