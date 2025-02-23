using API.Entities;

namespace API.Interfaces
{
    public interface IQuestionsRepository
    {
        Task<IReadOnlyList<QuizQuestion>> GetQuestionsAsync();
        Task<QuizQuestion> GetQuestionAsync(int Id);
    }
}