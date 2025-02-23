using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class AnswerRepository : IAnswersRepository
    {
        private readonly DataContext _context;
        public AnswerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserQuizAnswer> GetUserAnswerAsync(string userId, int questionId)
        {
            return await _context.UserQuizAnswers.FindAsync(userId, questionId);
        }

        public async Task<IReadOnlyList<UserQuizAnswer>> GetUserAnswerAllAsync(string userId)
        {
            return await _context.UserQuizAnswers.Where(x => x.PlayerId == userId).Include(x => x.Question).ToListAsync();
        }

        public async Task<UserQuizAnswer> SetUserAnswerAsync(UserQuizAnswer userQuizAnswer)
        {
            var result = await _context.UserQuizAnswers.AddAsync(userQuizAnswer);
            await _context.SaveChangesAsync();
            return userQuizAnswer;
        }

        public async Task<bool> DeleteAnswersAsync(string userId)
        {
            var answers = await _context.UserQuizAnswers.Where(x => x.PlayerId == userId).ToListAsync();

            foreach(var answer in answers)
            {
                _context.UserQuizAnswers.Remove(answer);
            }

            if(await _context.SaveChangesAsync() == 1) return false;
            return true;
        }
    }
}