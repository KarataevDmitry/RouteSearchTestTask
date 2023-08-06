using System.Diagnostics;

namespace TaskSolution.DAL.Data;

public class ProviderOneSearchRequest
{
    //public static bool TryParse(string query, out QueryParameters parameters)
    //{
    //    Debugger.Break();
    //    var splitted = query.Split('=');

    //    parameters = new QueryParameters();
    //    return true;
            
    //}
    public bool? FromCache { get; set; }
    public DateTime? MinStartDateTimeUTC { get; set; } 
    public DateTime? MaxStartDateTimeUTC { get; set; } 
    public DateTime? MinArrivalDateTimeUTC { get; set; }
    public DateTime? MaxArrivalDateTimeUTC { get; set; }
    public decimal? MinCost { get; set; }
    public decimal? MaxCost { get; set; } 
    public string? EndPointStartsWith { get; set; } = null;
    public string? EndPointEndsWith { get; set; } = null;
    public string? EndPointContains { get; set; } = null;
    public string? StartPointStartsWith { get; set; } = null;
    public string? StartPointEndsWith { get; set; } = null;
    public string? StartPointContains { get; set; } = null;

}