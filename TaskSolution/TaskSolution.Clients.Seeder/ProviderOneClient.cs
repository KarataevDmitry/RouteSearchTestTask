// b992185ebfa5ee021ae512214d7c6349
// This file generated for ZeroQL.
// <auto-generated/>
#pragma warning disable 8618
#nullable enable
namespace TaskSolution.Clients.Seeder
{
    using System;
    using System.Linq;
    using System.Text.Json.Serialization;
    using System.Text.Json.Nodes;
    using System.Text.Json;
    using ZeroQL;
    using ZeroQL.Json;

    public class ProviderOneZeroQLClient : global::ZeroQL.GraphQLClient<Query, Mutation>
    {
        public ProviderOneZeroQLClient(global::System.Net.Http.HttpClient client, global::ZeroQL.Pipelines.IGraphQLQueryPipeline? queryPipeline = null) : base(client, queryPipeline)
        {
        }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public class Mutation : global::ZeroQL.Internal.IMutation
    {
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never), JsonPropertyName("addTravelRoute")]
        public TravelRoute __AddTravelRoute { get; set; }

        [ZeroQL.GraphQLFieldSelector("addTravelRoute")]
        public T AddTravelRoute<T>(string startPointName = default !, string endPointName = default !, DateTimeOffset startDateTimeUTC = default !, DateTimeOffset arrivalDateTimeUTC = default !, TimeSpan timeToLive = default !, int cost = default !, Func<TravelRoute, T> selector = default !)
        {
            return __AddTravelRoute is null ? throw new NullReferenceException("AddTravelRoute is null but it should not be null. Schema can be outdated.") : selector(__AddTravelRoute);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public class Query : global::ZeroQL.Internal.IQuery
    {
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never), JsonPropertyName("travelRoutes")]
        public TravelRoute[] __TravelRoutes { get; set; }

        [ZeroQL.GraphQLFieldSelector("travelRoutes")]
        public T[] TravelRoutes<T>(TravelRouteFilterInput? where = default !, TravelRouteSortInput[]? order = default !, Func<TravelRoute, T> selector = default !)
        {
            return __TravelRoutes is null ? throw new NullReferenceException("TravelRoutes is null but it should not be null. Schema can be outdated.") : __TravelRoutes.Select(o => o is null ? throw new NullReferenceException("TravelRoutes is null but it should not be null. Schema can be outdated.") : selector(o)).ToArray();
        }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public class TravelRoute
    {
        [ZeroQL.GraphQLFieldSelector("id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [ZeroQL.GraphQLFieldSelector("startPoint")]
        [JsonPropertyName("startPoint")]
        public string StartPoint { get; set; }

        [ZeroQL.GraphQLFieldSelector("endPoint")]
        [JsonPropertyName("endPoint")]
        public string EndPoint { get; set; }

        [ZeroQL.GraphQLFieldSelector("startDateTimeUTC")]
        [JsonPropertyName("startDateTimeUTC")]
        public DateTimeOffset StartDateTimeUTC { get; set; }

        [ZeroQL.GraphQLFieldSelector("arrivalDateTimeUTC")]
        [JsonPropertyName("arrivalDateTimeUTC")]
        public DateTimeOffset ArrivalDateTimeUTC { get; set; }

        [ZeroQL.GraphQLFieldSelector("timeToLive")]
        [JsonPropertyName("timeToLive")]
        public TimeSpan TimeToLive { get; set; }

        [ZeroQL.GraphQLFieldSelector("cost")]
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public class DateTimeOperationFilterInput
    {
        [JsonPropertyName("eq")]
        public DateTimeOffset? Eq { get; set; }

        [JsonPropertyName("neq")]
        public DateTimeOffset? Neq { get; set; }

        [JsonPropertyName("in")]
        public DateTimeOffset[]? In { get; set; }

        [JsonPropertyName("nin")]
        public DateTimeOffset[]? Nin { get; set; }

        [JsonPropertyName("gt")]
        public DateTimeOffset? Gt { get; set; }

        [JsonPropertyName("ngt")]
        public DateTimeOffset? Ngt { get; set; }

        [JsonPropertyName("gte")]
        public DateTimeOffset? Gte { get; set; }

        [JsonPropertyName("ngte")]
        public DateTimeOffset? Ngte { get; set; }

        [JsonPropertyName("lt")]
        public DateTimeOffset? Lt { get; set; }

        [JsonPropertyName("nlt")]
        public DateTimeOffset? Nlt { get; set; }

        [JsonPropertyName("lte")]
        public DateTimeOffset? Lte { get; set; }

        [JsonPropertyName("nlte")]
        public DateTimeOffset? Nlte { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public class IntOperationFilterInput
    {
        [JsonPropertyName("eq")]
        public int? Eq { get; set; }

        [JsonPropertyName("neq")]
        public int? Neq { get; set; }

        [JsonPropertyName("in")]
        public int[]? In { get; set; }

        [JsonPropertyName("nin")]
        public int[]? Nin { get; set; }

        [JsonPropertyName("gt")]
        public int? Gt { get; set; }

        [JsonPropertyName("ngt")]
        public int? Ngt { get; set; }

        [JsonPropertyName("gte")]
        public int? Gte { get; set; }

        [JsonPropertyName("ngte")]
        public int? Ngte { get; set; }

        [JsonPropertyName("lt")]
        public int? Lt { get; set; }

        [JsonPropertyName("nlt")]
        public int? Nlt { get; set; }

        [JsonPropertyName("lte")]
        public int? Lte { get; set; }

        [JsonPropertyName("nlte")]
        public int? Nlte { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public class StringOperationFilterInput
    {
        [JsonPropertyName("and")]
        public StringOperationFilterInput[]? And { get; set; }

        [JsonPropertyName("or")]
        public StringOperationFilterInput[]? Or { get; set; }

        [JsonPropertyName("eq")]
        public string? Eq { get; set; }

        [JsonPropertyName("neq")]
        public string? Neq { get; set; }

        [JsonPropertyName("contains")]
        public string? Contains { get; set; }

        [JsonPropertyName("ncontains")]
        public string? Ncontains { get; set; }

        [JsonPropertyName("in")]
        public string[]? In { get; set; }

        [JsonPropertyName("nin")]
        public string[]? Nin { get; set; }

        [JsonPropertyName("startsWith")]
        public string? StartsWith { get; set; }

        [JsonPropertyName("nstartsWith")]
        public string? NstartsWith { get; set; }

        [JsonPropertyName("endsWith")]
        public string? EndsWith { get; set; }

        [JsonPropertyName("nendsWith")]
        public string? NendsWith { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public class TimeSpanOperationFilterInput
    {
        [JsonPropertyName("eq")]
        public TimeSpan? Eq { get; set; }

        [JsonPropertyName("neq")]
        public TimeSpan? Neq { get; set; }

        [JsonPropertyName("in")]
        public TimeSpan[]? In { get; set; }

        [JsonPropertyName("nin")]
        public TimeSpan[]? Nin { get; set; }

        [JsonPropertyName("gt")]
        public TimeSpan? Gt { get; set; }

        [JsonPropertyName("ngt")]
        public TimeSpan? Ngt { get; set; }

        [JsonPropertyName("gte")]
        public TimeSpan? Gte { get; set; }

        [JsonPropertyName("ngte")]
        public TimeSpan? Ngte { get; set; }

        [JsonPropertyName("lt")]
        public TimeSpan? Lt { get; set; }

        [JsonPropertyName("nlt")]
        public TimeSpan? Nlt { get; set; }

        [JsonPropertyName("lte")]
        public TimeSpan? Lte { get; set; }

        [JsonPropertyName("nlte")]
        public TimeSpan? Nlte { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public class TravelRouteFilterInput
    {
        [JsonPropertyName("and")]
        public TravelRouteFilterInput[]? And { get; set; }

        [JsonPropertyName("or")]
        public TravelRouteFilterInput[]? Or { get; set; }

        [JsonPropertyName("id")]
        public UuidOperationFilterInput? Id { get; set; }

        [JsonPropertyName("startPoint")]
        public StringOperationFilterInput? StartPoint { get; set; }

        [JsonPropertyName("endPoint")]
        public StringOperationFilterInput? EndPoint { get; set; }

        [JsonPropertyName("startDateTimeUTC")]
        public DateTimeOperationFilterInput? StartDateTimeUTC { get; set; }

        [JsonPropertyName("arrivalDateTimeUTC")]
        public DateTimeOperationFilterInput? ArrivalDateTimeUTC { get; set; }

        [JsonPropertyName("timeToLive")]
        public TimeSpanOperationFilterInput? TimeToLive { get; set; }

        [JsonPropertyName("cost")]
        public IntOperationFilterInput? Cost { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public class TravelRouteSortInput
    {
        [JsonPropertyName("id")]
        public SortEnumType? Id { get; set; }

        [JsonPropertyName("startPoint")]
        public SortEnumType? StartPoint { get; set; }

        [JsonPropertyName("endPoint")]
        public SortEnumType? EndPoint { get; set; }

        [JsonPropertyName("startDateTimeUTC")]
        public SortEnumType? StartDateTimeUTC { get; set; }

        [JsonPropertyName("arrivalDateTimeUTC")]
        public SortEnumType? ArrivalDateTimeUTC { get; set; }

        [JsonPropertyName("timeToLive")]
        public SortEnumType? TimeToLive { get; set; }

        [JsonPropertyName("cost")]
        public SortEnumType? Cost { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public class UuidOperationFilterInput
    {
        [JsonPropertyName("eq")]
        public Guid? Eq { get; set; }

        [JsonPropertyName("neq")]
        public Guid? Neq { get; set; }

        [JsonPropertyName("in")]
        public Guid[]? In { get; set; }

        [JsonPropertyName("nin")]
        public Guid[]? Nin { get; set; }

        [JsonPropertyName("gt")]
        public Guid? Gt { get; set; }

        [JsonPropertyName("ngt")]
        public Guid? Ngt { get; set; }

        [JsonPropertyName("gte")]
        public Guid? Gte { get; set; }

        [JsonPropertyName("ngte")]
        public Guid? Ngte { get; set; }

        [JsonPropertyName("lt")]
        public Guid? Lt { get; set; }

        [JsonPropertyName("nlt")]
        public Guid? Nlt { get; set; }

        [JsonPropertyName("lte")]
        public Guid? Lte { get; set; }

        [JsonPropertyName("nlte")]
        public Guid? Nlte { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode ( "ZeroQL" ,  "4.0.0.0" )]
    public enum SortEnumType
    {
        [ZeroQL.GraphQLFieldSelector("ASC")]
        Asc,
        [ZeroQL.GraphQLFieldSelector("DESC")]
        Desc
    }

    internal static class JsonConvertersInitializers
    {
        [global::System.Runtime.CompilerServices.ModuleInitializer]
        public static void Init()
        {
            global::ZeroQL.Json.ZeroQLJsonSerializersStore.Converters[typeof(global::TaskSolution.Clients.Seeder.SortEnumType)] = new global::ZeroQL.Json.ZeroQLEnumConverter<global::TaskSolution.Clients.Seeder.SortEnumType>(new global::System.Collections.Generic.Dictionary<string, global::TaskSolution.Clients.Seeder.SortEnumType>{{"ASC", global::TaskSolution.Clients.Seeder.SortEnumType.Asc}, {"DESC", global::TaskSolution.Clients.Seeder.SortEnumType.Desc}, }, new global::System.Collections.Generic.Dictionary<global::TaskSolution.Clients.Seeder.SortEnumType, string>{{global::TaskSolution.Clients.Seeder.SortEnumType.Asc, "ASC"}, {global::TaskSolution.Clients.Seeder.SortEnumType.Desc, "DESC"}, });
        }
    }
}
#pragma warning restore 8618
