namespace GateWayService.Services.Interfaces
{
    public interface ILeadershipCommunicationService
    {
        Task<IEnumerable<object>> GetLeaderboardAsync();
    }
}
