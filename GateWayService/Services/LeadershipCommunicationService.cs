using GateWayService.Services.Interfaces;

namespace GateWayService.Services
{
    public class LeadershipCommunicationService: ILeadershipCommunicationService
    {
        private readonly HttpClient _client;
        private readonly ILogger<LeadershipCommunicationService> _logger;
        public LeadershipCommunicationService(HttpClient client, ILogger<LeadershipCommunicationService> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<IEnumerable<object>> GetLeaderboardAsync()
        {
            try
            {
                var response = await _client.GetAsync("api/leadership");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("LeadershipService returned {StatusCode}", response.StatusCode);
                    return new List<object>(); // return empty list instead of error string
                }

                var leaderboard = await response.Content.ReadFromJsonAsync<IEnumerable<object>>();
                return leaderboard ?? new List<object>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error connecting to LeadershipService");
                return new List<object>();
            }
        }

    }
}
