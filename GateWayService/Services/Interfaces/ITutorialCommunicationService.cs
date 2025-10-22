using GateWayService.DTOs.Tutorial;

namespace GateWayService.Services.Interfaces
{
    public interface ITutorialCommunicationService
    {
        //Course
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto> GetByIdAsync(int id);
        Task<CourseDto> CreateAsync(CourseDto course);
        Task<CourseDto> UpdateAsync(int id, CourseDto course);
        Task<bool> DeleteAsync(int id);

        //Topic
        Task<IEnumerable<TopicDto>> GetAllTopicsAsync(int courseId);
        Task<TopicDto> GetTopicByIdAsync(int id);
        Task<TopicDto> CreateTopicAsync(TopicDto topic);
        Task<TopicDto> UpdateTopicAsync(int id, TopicDto topic);
        Task<bool> DeleteTopicAsync(int id);

        //Content
        Task<IEnumerable<ContentDto>> GetAllContentsAsync();
        Task<ContentDto> GetContentByIdAsync(int id);
        Task<ContentDto> CreateContentAsync(ContentDto content);
        Task<ContentDto> UpdateContentAsync(int id, ContentDto content);
        Task<bool> DeleteContentAsync(int id);

        //SubTopic
        Task<IEnumerable<SubTopicDto>> GetAllSubTopicsAsync();
        Task<SubTopicDto> GetSubTopicByIdAsync(int id);
        Task<SubTopicDto> CreateSubTopicAsync(SubTopicDto subTopic);
        Task<SubTopicDto> UpdateSubTopicAsync(int id, SubTopicDto subTopic);
        Task<bool> DeleteSubTopicAsync(int id);



    }
}
