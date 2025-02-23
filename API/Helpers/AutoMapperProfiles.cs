using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<QuizQuestion, QuizQuestionDTO>();
            CreateMap<UserQuizAnswer, UserQuizAnswersDTO>()
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => 
                    src.Question.Question));
        }
    }
}