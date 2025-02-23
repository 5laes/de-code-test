using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        public DataContext _context { get; }
        public QuestionsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<QuizQuestion>> GetQuestionsAsync()
        {
            return await _context.QuizQuestions.ToListAsync();
        }

        public async Task<QuizQuestion> GetQuestionAsync(int Id)
        {
            return await _context.QuizQuestions.FindAsync(Id);
        }
    }
}