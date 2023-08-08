using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TaskSolution.API.Providers.AggregateSearch.HealthChecks
{
    public class ProviderOneHealthCheck : IHealthCheck
    {
        HttpClient _httpClient;
        public ProviderOneHealthCheck(HttpClient httpClient) => _httpClient = httpClient;
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:4883/ping");
                if (response.IsSuccessStatusCode) { return HealthCheckResult.Healthy("Провайдер 1 доступен"); }
            }
            catch (Exception)
            {

                return HealthCheckResult.Degraded("Провайдер 1 недоступен");
            };
            return HealthCheckResult.Unhealthy();
          

        }
    }
}
