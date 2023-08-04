using System.Diagnostics;

namespace TaskSolution.DAL.Data;

public class QueryParameters
{
    //public static bool TryParse(string query, out QueryParameters parameters)
    //{
    //    Debugger.Break();
    //    var splitted = query.Split('=');

    //    parameters = new QueryParameters();
    //    return true;
            
    //}
    public bool? FromCache { get; set; }
    public DateTime? MinStartDateTimeUTC { get; set; } =new  DateTime(1,1,1).ToUniversalTime();
    public DateTime? MaxStartDateTimeUTC { get; set; } = new DateTime(9999, 12, 31).ToUniversalTime();
    public DateTime? MinArrivalDateTimeUTC { get; set; } = new DateTime(1, 1, 1).ToUniversalTime();
    public DateTime? MaxArrivalDateTimeUTC { get; set; } = new DateTime(9999, 12, 31).ToUniversalTime();
    public decimal? MinCost { get; set; } = decimal.MinValue;
    public decimal? MaxCost { get; set; } = decimal.MaxValue;
    public string? EndPointStartsWith { get; set; } = null;
    public string? EndPointEndsWith { get; set; } = null;
    public string? EndPointContains { get; set; } = null;
    public string? StartPointStartsWith { get; set; } = null;
    public string? StartPointEndsWith { get; set; } = null;
    public string? StartPointContains { get; set; } = null;

}