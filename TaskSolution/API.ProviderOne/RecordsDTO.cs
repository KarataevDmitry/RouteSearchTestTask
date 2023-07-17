namespace TaskSolution.DTO;
record class TravelPointDTO(string Name);
record class TravelRouteDTO(TravelPointDTO StartPoint, TravelPointDTO DestinationPoint, DateTime StartTimeUTC, DateTime ArrivalTimeUTC, decimal Cost, DateTime TimeToLive);