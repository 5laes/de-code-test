using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserQuizAnswerDTO
    {
        public string UserAnswer { get; set; }
        public int QuestionId { get; set; }
    }
}