using Azure;
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
            var leaderResponse = await  _client.GetAsync("api/v1/LeaderBoard");
            leaderResponse.EnsureSuccessStatusCode();
            return await leaderResponse.Content.ReadFromJsonAsync<IEnumerable<LeaderBoardDto>>();
        }
        public async Task<LeaderBoardDto> GetByIdAsync(int Id)
        {
            var leaderResponse = await _client.GetAsync($"api/v1/LeaderBoard/{Id}");
            leaderResponse.EnsureSuccessStatusCode();
            return await leaderResponse.Content.ReadFromJsonAsync<LeaderBoardDto>();
        }
        public async Task<LeaderBoardDto> CreateAsync(LeaderBoardDto leaderboard)
        {
            var leaderResponse = await _client.PostAsJsonAsync("api/v1/LeaderBoard", leaderboard);
            leaderResponse.EnsureSuccessStatusCode();
            return await leaderResponse.Content.ReadFromJsonAsync<LeaderBoardDto>();
        }

        public async Task<LeaderBoardDto> UpdateAsync(int id,LeaderBoardDto leaderboard)
        {
            var leaderResponse = await _client.PutAsJsonAsync($"api/v1/LeaderBoard/{id}", leaderboard);
            leaderResponse.EnsureSuccessStatusCode();
            return await leaderResponse.Content.ReadFromJsonAsync<LeaderBoardDto>();
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var leaderResponse = await _client.DeleteAsync($"api/v1/LeaderBoard/{Id}");
            return leaderResponse.IsSuccessStatusCode;
        }

        //option
        public async Task<IEnumerable<OptionDto>> GetAllOptionsAsync()
        {
            var optionResponse = await _client.GetAsync("api/v1/Option/GetAllOptions");
            optionResponse.EnsureSuccessStatusCode();
            return await optionResponse.Content.ReadFromJsonAsync<IEnumerable<OptionDto>>();
        }
        public async Task<OptionDto> GetOptionByIdAsync(int optionId)
        {
            var optionResponse = await _client.GetAsync($"api/v1/Option/{optionId}");
            optionResponse.EnsureSuccessStatusCode();
            return await optionResponse.Content.ReadFromJsonAsync<OptionDto>();
        }
        public async Task<OptionDto> CreateOptionAsync(OptionDto option)
        {
            var optionResponse = await _client.PostAsJsonAsync("api/v1/Option", option);
            optionResponse.EnsureSuccessStatusCode();
            return await optionResponse.Content.ReadFromJsonAsync<OptionDto>();
        }
        public async Task<OptionDto> UpdateOptionAsync(int id, OptionDto option)
        {
            var optionResponse = await _client.PutAsJsonAsync($"api/v1/Option/{id}", option);
            optionResponse.EnsureSuccessStatusCode();
            return await optionResponse.Content.ReadFromJsonAsync<OptionDto>();
        }
        public async Task<bool> DeleteOptionAsync(int optionId)
        {
            var optionResponse = await _client.DeleteAsync($"api/v1/Option/{optionId}");
            return optionResponse.IsSuccessStatusCode;
        }

        //participant
        public async Task<IEnumerable<ParticipantDto>> GetAllParticipants()
        {
            var participantResponse = await _client.GetAsync("api/v1/Participant");
            participantResponse.EnsureSuccessStatusCode();
            return await participantResponse.Content.ReadFromJsonAsync<IEnumerable<ParticipantDto>>();
        }
        public async Task<ParticipantDto> GetParticipantById(int id)
        {
            var participantResponse = await _client.GetAsync($"api/v1/Participant/{id}");
            participantResponse.EnsureSuccessStatusCode();
            return await participantResponse.Content.ReadFromJsonAsync<ParticipantDto> ();
        }
        public async Task<ParticipantDto> CreateParticipants(ParticipantDto participant)
        {
            var participantResponse = await _client.PostAsJsonAsync("api/v1/Participant",participant);
            participantResponse.EnsureSuccessStatusCode();
            return await participantResponse.Content.ReadFromJsonAsync<ParticipantDto>();
        }
        public async Task<ParticipantDto> UpdateParticipants(int id, ParticipantDto participant)
        {
            var participantResponse = await _client.PutAsJsonAsync($"api/v1/Participant/{id}",participant);
            participantResponse.EnsureSuccessStatusCode();
            return await participantResponse.Content.ReadFromJsonAsync<ParticipantDto>();
        }
        public async Task<bool> DeleteParticipants(int id)
        {
            var participantResponse = await _client.DeleteAsync($"api/v1/Participant/{id}");
            return participantResponse.IsSuccessStatusCode;
        }

        //questions
        public async Task<IEnumerable<QuestionsDto>> GetAllQuestionsAsync()
        {
            var QuestionResponse = await _client.GetAsync("api/v1/Question");
            QuestionResponse.EnsureSuccessStatusCode();
            return await QuestionResponse.Content.ReadFromJsonAsync<IEnumerable<QuestionsDto>>();
        }
        public async Task<QuestionsDto> GetQuestionByIdAsync(int questionId)
        {
            var QuestionResponse = await _client.GetAsync($"api/v1/Question/{questionId}");
            QuestionResponse.EnsureSuccessStatusCode();
            return await QuestionResponse.Content.ReadFromJsonAsync<QuestionsDto>();
        }
        public async Task<QuestionsDto> CreateQuestionAsync(QuestionsDto question)
        {
            var QuestionResponse = await _client.PostAsJsonAsync("api/v1/Question",question);
            QuestionResponse.EnsureSuccessStatusCode();
            return await QuestionResponse.Content.ReadFromJsonAsync<QuestionsDto>();
        }
        public async Task<QuestionsDto> UpdateQuestionAsync(int id, QuestionsDto question)
        {
            var QuestionResponse = await _client.PutAsJsonAsync($"api/v1/Question/{id}",question);
            QuestionResponse.EnsureSuccessStatusCode();
            return await QuestionResponse.Content.ReadFromJsonAsync<QuestionsDto>();
        }
        public async Task<bool> DeleteQuestionAsync(int questionId)
        {
            var QuestionResponse = await _client.DeleteAsync($"api/v1/Question/{questionId}");
            return QuestionResponse.IsSuccessStatusCode;
        }

        //response
        public async Task<IEnumerable<ResponseDto>> GetAllResponse()
        {
            var result = await _client.GetAsync("api/v1/Response");
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<IEnumerable<ResponseDto>>();
        }
        public async Task<ResponseDto> GetResponseById(int id)
        {
            var result = await _client.GetAsync($"api/v1/Response/{id}");
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<ResponseDto>();
        }
        public async Task<ResponseDto> CreateResponse(ResponseDto response)
        {
            var result = await _client.PostAsJsonAsync("api/v1/Response", response);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<ResponseDto>();
        }
        public async Task<ResponseDto> UpdateResponse(int id, ResponseDto response)
        {
            var result = await _client.PutAsJsonAsync($"api/v1/Response/{id}", response);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<ResponseDto>();
        }
        public async Task<bool> DeleteResponseById(int id)
        {
            var result = await _client.DeleteAsync($"api/v1/Response/{id}");
            return result.IsSuccessStatusCode;
        }
    }
}
