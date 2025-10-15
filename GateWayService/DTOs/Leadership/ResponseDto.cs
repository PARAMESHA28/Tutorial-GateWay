namespace GateWayService.DTOs.Leadership
{
    public class ResponseDto
    {
        public int ResponseId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime ResponseTime { get; set; }
        public int? OptionId { get; set; }
        public int QuestionId { get; set; }

    }
}
