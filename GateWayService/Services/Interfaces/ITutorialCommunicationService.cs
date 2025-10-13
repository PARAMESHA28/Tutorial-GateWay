using GateWayService.DTOs.Tutorial;

namespace GateWayService.Services.Interfaces
{
    public interface ITutorialCommunicationService
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto> GetByIdAsync(int id);
        Task<CourseDto> CreateAsync(CourseDto course);
        Task<CourseDto> UpdateAsync(int id, CourseDto course);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TopicDto>> GetAllTopicsAsync();
        Task<TopicDto> GetTopicByIdAsync(int id);
        Task<TopicDto> CreateTopicAsync(TopicDto topic);
        Task<TopicDto> UpdateTopicAsync(int id, TopicDto topic);
        Task<bool> DeleteTopicAsync(int id);
    }
}
