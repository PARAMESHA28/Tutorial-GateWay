using GateWayService.DTOs.Tutorial;
using GateWayService.Services.Interfaces;
using System.Net.Http.Json;

namespace GateWayService.Services
{
    public class TutorialCommunicationService : ITutorialCommunicationService
    {
        private readonly HttpClient _client;
        private readonly ILogger<TutorialCommunicationService> _logger;

        public TutorialCommunicationService(HttpClient client, ILogger<TutorialCommunicationService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("api/Course");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<CourseDto>>();
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync($"api/Course/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<CourseDto> CreateAsync(CourseDto course)
        {
            var response = await _client.PostAsJsonAsync("api/Course", course);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<CourseDto> UpdateAsync(int id, CourseDto course)
        {
            var response = await _client.PutAsJsonAsync($"api/Course/{id}", course);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/Course/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<TopicDto>> GetAllTopicsAsync()
        {
            var response = await _client.GetAsync("api/Topics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<TopicDto>>();
        }
        public async Task<TopicDto> GetTopicByIdAsync(int id)
        {
            var response = await _client.GetAsync($"api/Topics/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TopicDto>();
        }
        public async Task<TopicDto> CreateTopicAsync(TopicDto topic)
        {
            var response = await _client.PostAsJsonAsync("api/Topics", topic);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TopicDto>();
        }
        public async Task<TopicDto> UpdateTopicAsync(int id, TopicDto topic)
        {
            var response = await _client.PutAsJsonAsync($"api/Topics/{id}", topic);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TopicDto>();
        }
        public async Task<bool> DeleteTopicAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/Topics/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
