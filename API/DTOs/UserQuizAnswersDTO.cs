using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserQuizAnswersDTO
    {
        public string UserAnswer { get; set; }
        public string Question { get; set; }
        public bool IsAnswerCorrect { get; set; }
    }
}