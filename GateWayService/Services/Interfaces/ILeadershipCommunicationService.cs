using Azure;
using GateWayService.DTOs.Leadership;

namespace GateWayService.Services.Interfaces
{
    public interface ILeadershipCommunicationService
    {
        //LeaderBoard
        Task<IEnumerable<LeaderBoardDto>> GetAllAsync();
        Task<LeaderBoardDto> GetByIdAsync(int Id);
        Task<LeaderBoardDto> CreateAsync(LeaderBoardDto leaderboard);
        Task<LeaderBoardDto> UpdateAsync(int id, LeaderBoardDto leaderboard);
        Task<bool> DeleteAsync(int Id);

        //option
        Task<IEnumerable<OptionDto>> GetAllOptionsAsync();
        Task<OptionDto> GetOptionByIdAsync(int optionId);
        Task<OptionDto> CreateOptionAsync(OptionDto option);
        Task<OptionDto> UpdateOptionAsync(int id, OptionDto option);
        Task<bool> DeleteOptionAsync(int optionId);

        //participant
        Task<IEnumerable<ParticipantDto>> GetAllParticipants();
        Task<ParticipantDto> GetParticipantById(int id);
        Task<ParticipantDto> CreateParticipants(ParticipantDto participant);
        Task<ParticipantDto> UpdateParticipants(int id,ParticipantDto participant);
        Task<bool> DeleteParticipants(int id);

        //questions
        Task<IEnumerable<QuestionsDto>> GetAllQuestionsAsync();
        Task<QuestionsDto> GetQuestionByIdAsync(int questionId);
        Task<QuestionsDto> CreateQuestionAsync(QuestionsDto question);
        Task<QuestionsDto> UpdateQuestionAsync(int id, QuestionsDto question);
        Task<bool> DeleteQuestionAsync(int questionId);

        //response
        Task<IEnumerable<ResponseDto>> GetAllResponse();
        Task<ResponseDto> GetResponseById(int id);
        Task<ResponseDto> CreateResponse(ResponseDto response);
        Task<ResponseDto> UpdateResponse(int id, ResponseDto response);
        Task<bool> DeleteResponseById(int id);

    }
}
