namespace GateWayService.DTOs.Leadership
{
    public class OptionDto
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
