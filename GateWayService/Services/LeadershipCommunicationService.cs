using GateWayService.DTOs.Leadership;
using GateWayService.DTOs.Tutorial;
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
        //LeaderBoard
        public async Task<IEnumerable<LeaderBoardDto>> GetAllAsync()
        {
            var response = await  _client.GetAsync("api/v1/LeaderBoard");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<LeaderBoardDto>>();
        }
        public async Task<LeaderBoardDto> GetByIdAsync(int Id)
        {
            var response = await _client.GetAsync($"api/v1/LeaderBoard/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LeaderBoardDto>();
        }
        public async Task<LeaderBoardDto> CreateAsync(LeaderBoardDto leaderboard)
        {
            var response = await _client.PostAsJsonAsync("api/v1/LeaderBoard", leaderboard);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LeaderBoardDto>();
        }

        public async Task<LeaderBoardDto> UpdateAsync(int id,LeaderBoardDto leaderboard)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/LeaderBoard/{id}", leaderboard);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LeaderBoardDto>();
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var response = await _client.DeleteAsync($"api/v1/LeaderBoard/{Id}");
            return response.IsSuccessStatusCode;
        }

        //option
        public async Task<IEnumerable<OptionDto>> GetAllOptionsAsync()
        {
            var response = await _client.GetAsync("api/v1/Option/GetAllOptions");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<OptionDto>>();
        }
        public async Task<OptionDto> GetOptionByIdAsync(int optionId)
        {
            var response = await _client.GetAsync($"api/v1/Option/{optionId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OptionDto>();
        }
        public async Task<OptionDto> CreateOptionAsync(OptionDto option)
        {
            var response = await _client.PostAsJsonAsync("api/v1/Option", option);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OptionDto>();
        }
        public async Task<OptionDto> UpdateOptionAsync(int id, OptionDto option)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/Option/{id}", option);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OptionDto>();
        }
        public async Task<bool> DeleteOptionAsync(int optionId)
        {
            var response = await _client.DeleteAsync($"api/v1/Option/{optionId}");
            return response.IsSuccessStatusCode;
        }

        //participant
        public async Task<IEnumerable<ParticipantDto>> GetAllParticipants()
        {
            var response = await _client.GetAsync("api/v1/Participant");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ParticipantDto>>();
        }
        public async Task<ParticipantDto> GetParticipantById(int id)
        {
            var response = await _client.GetAsync($"api/v1/Participant/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ParticipantDto> ();
        }
        public async Task<ParticipantDto> CreateParticipants(ParticipantDto participant)
        {
            var response = await _client.PostAsJsonAsync("api/v1/Participant",participant);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ParticipantDto>();
        }
        public async Task<ParticipantDto> UpdateParticipants(int id, ParticipantDto participant)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/Participant/{id}",participant);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ParticipantDto>();
        }
        public async Task<bool> DeleteParticipants(int id)
        {
            var response = await _client.GetAsync($"api/v1/Participant/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
