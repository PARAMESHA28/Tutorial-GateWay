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
            _logger.LogInformation("Fetching all courses from Tutorial Service." );
            var response = await _client.GetAsync("api/v1/Course");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<CourseDto>>();
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync($"api/v1/Course/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<CourseDto> CreateAsync(CourseDto course)
        {
            var response = await _client.PostAsJsonAsync("api/v1/Course", course);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<CourseDto> UpdateAsync(int id, CourseDto course)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/Course/{id}", course);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/v1/Course/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<TopicDto>> GetAllTopicsAsync()
        {
            var response = await _client.GetAsync("api/v1/Topics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<TopicDto>>();
        }
        public async Task<TopicDto> GetTopicByIdAsync(int id)
        {
            var response = await _client.GetAsync($"api/v1/Topics/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TopicDto>();
        }
        public async Task<TopicDto> CreateTopicAsync(TopicDto topic)
        {
            var response = await _client.PostAsJsonAsync("api/v1/Topics", topic);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TopicDto>();
        }
        public async Task<TopicDto> UpdateTopicAsync(int id, TopicDto topic)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/Topics/{id}", topic);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TopicDto>();
        }
        public async Task<bool> DeleteTopicAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/v1/Topics/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<ContentDto>> GetAllContentsAsync()
        {
            var response = await _client.GetAsync("api/v1/Content");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ContentDto>>();
        }
        public async Task<ContentDto> GetContentByIdAsync(int id)
        {
            var response = await _client.GetAsync($"api/v1/Content/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ContentDto>();
        }
        public async Task<ContentDto> CreateContentAsync(ContentDto content)
        {
            var response = await _client.PostAsJsonAsync("api/v1/Content", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ContentDto>();
        }
        public async Task<ContentDto> UpdateContentAsync(int id, ContentDto content)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/Content/{id}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ContentDto>();
        }
        public async Task<bool> DeleteContentAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/v1/Content/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<SubTopicDto>> GetAllSubTopicsAsync()
        {
            var response = await _client.GetAsync("api/v1/SubTopics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<SubTopicDto>>();
        }
        public async Task<SubTopicDto> GetSubTopicByIdAsync(int id)
        {
            var response = await _client.GetAsync($"api/v1/SubTopics/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SubTopicDto>();
        }
        public async Task<SubTopicDto> CreateSubTopicAsync(SubTopicDto subTopic)
        {
            var response = await _client.PostAsJsonAsync("api/v1/SubTopics", subTopic);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SubTopicDto>();
        }
        public async Task<SubTopicDto> UpdateSubTopicAsync(int id, SubTopicDto subTopic)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/SubTopics/{id}", subTopic);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SubTopicDto>();
        }
        public async Task<bool> DeleteSubTopicAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/v1/SubTopics/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
