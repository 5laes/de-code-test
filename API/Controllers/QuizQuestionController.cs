using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class QuizQuestionController : BaseApiController
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IMapper _mapper;
        public QuizQuestionController(IQuestionsRepository questionsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _questionsRepository = questionsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<QuizQuestionDTO>>> GetQuestions()
        {
            var result = await _questionsRepository.GetQuestionsAsync();
            if(result == null) return NotFound(_mapper.Map<IReadOnlyList<QuizQuestionDTO>>(result));
            return Ok(_mapper.Map<IReadOnlyList<QuizQuestionDTO>>(result));
        }
    }
}