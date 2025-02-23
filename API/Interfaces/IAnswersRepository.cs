using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IAnswersRepository
    {
        Task<UserQuizAnswer> GetUserAnswerAsync(string userId, int questionId);
        Task<IReadOnlyList<UserQuizAnswer>> GetUserAnswerAllAsync(string userId);
        Task<UserQuizAnswer> SetUserAnswerAsync(UserQuizAnswer userQuizAnswer);
        Task<bool> DeleteAnswersAsync(string userId);
    }
}