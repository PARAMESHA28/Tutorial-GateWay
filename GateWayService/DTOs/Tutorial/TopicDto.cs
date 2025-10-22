namespace GateWayService.DTOs.Tutorial
{
    public class TopicDto
    {
        public int TopicId { get; set; }

        public int CourseId { get; set; }

        public string TopicName { get; set; } = string.Empty;

        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }


        public List<SubTopicDto> SubTopics { get; set; } = new List<SubTopicDto>();
    }
}
