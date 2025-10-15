namespace GateWayService.DTOs.Leadership
{
    public class LeaderBoardDto
    {
        public int LeaderboardId { get; set; }
        public int QuizId { get; set; }
        public int ParticipantId { get; set; }
        public int Score { get; set; }
        public int Rank { get; set; }
    }
}
