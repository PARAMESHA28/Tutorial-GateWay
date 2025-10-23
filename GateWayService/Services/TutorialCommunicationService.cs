using GateWayService.DTOs.Tutorial;
using GateWayService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
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
            var response = await _client.GetAsync("api/v1/Courses");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<CourseDto>>();
        }

        public async Task<CourseDto> GetByIdAsync(int courseId)
        {
            var response = await _client.GetAsync($"api/v1/Courses/{courseId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<CourseDto> CreateAsync(CourseDto course)
        {
            var response = await _client.PostAsJsonAsync("api/v1/Courses", course);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<CourseDto> UpdateAsync(int id, CourseDto course)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/Courses/{id}", course);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/v1/Courses/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<IEnumerable<TopicDto>> GetAllTopicsAsync([FromQuery] int courseId)
        {
            var response = await _client.GetAsync($"api/v1/Courses/{courseId}/topics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<TopicDto>>();
        }
        public async Task<TopicDto> GetTopicByIdAsync(int id)
        {
            var response = await _client.GetAsync($"api/v1/Courses/topics/{id}");
            response.EnsureSuccessStatusCode();
            var topics = await response.Content.ReadFromJsonAsync<List<TopicDto>>();
            return topics?.FirstOrDefault(); // Return the first item or null

        }
        public async Task<TopicDto> CreateTopicAsync(TopicDto topic)
        {
            var response = await _client.PostAsJsonAsync("api/v1/Courses/topics", topic);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TopicDto>();
        }
        public async Task<TopicDto> UpdateTopicAsync(int id, TopicDto topic)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/Courses/topics/{id}", topic);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TopicDto>();
        }
        public async Task<bool> DeleteTopicAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/v1/Courses/topics/{id}");
            return response.IsSuccessStatusCode;
        }
      
        public async Task<IEnumerable<SubTopicDto>> GetAllSubTopicsByTopicIdAsync(int topicId)
        {
            var response = await _client.GetAsync($"api/v1/Courses/topics/{topicId}/subtopics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<SubTopicDto>>();
        }
        public async Task<SubTopicDto> GetSubTopicByIdAsync(int id)
        {
            var response = await _client.GetAsync($"api/v1/Courses/subtopics/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SubTopicDto>();
        }
        public async Task<SubTopicDto> CreateSubTopicAsync(SubTopicDto subTopic)
        {
            var response = await _client.PostAsJsonAsync("api/v1/Courses/topics/subtopics", subTopic);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SubTopicDto>();
        }
        public async Task<SubTopicDto> UpdateSubTopicAsync(int id, SubTopicDto subTopic)
        {
            var response = await _client.PutAsJsonAsync($"api/v1/Courses/subtopics/{id}", subTopic);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SubTopicDto>();
        }
        public async Task<bool> DeleteSubTopicAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/v1/Courses/subtopics/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
