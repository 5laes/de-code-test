using System.Text.Json.Serialization;

namespace API.Entities
{
    public class UserQuizAnswer
    {
        public int Id { get; set; }
        public string UserAnswer { get; set; }
        public bool IsAnswerCorrect { get; set; }
        public string PlayerId { get; set; }
        [JsonIgnore]
        public AppUser Player { get; set; }
        public int QuestionId { get; set; }
        [JsonIgnore]
        public QuizQuestion Question { get; set; }
    }
}