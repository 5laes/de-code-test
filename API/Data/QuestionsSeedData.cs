using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class QuestionsSeedData
    {
        public static async Task SeedData(DataContext context)
        {
            if(await context.QuizQuestions.AnyAsync()) return;

            var questionsData = await File.ReadAllTextAsync("Data/QuestionsSeedData.json");
            var questions = JsonSerializer.Deserialize<List<QuizQuestion>>(questionsData);

            foreach (var question in questions)
            {
                context.QuizQuestions.Add(question);
            }

            await context.SaveChangesAsync();
        }
    }
}