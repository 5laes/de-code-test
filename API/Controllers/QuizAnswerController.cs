using System.Security.Claims;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace API.Controllers
{
    public class QuizAnswerController : BaseApiController
    {
        private readonly IAnswersRepository _answersRepository;
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public QuizAnswerController(IAnswersRepository answersRepository, IMapper mapper, UserManager<AppUser> userManager,
            IQuestionsRepository questionsRepository)
        {
            _userManager = userManager;
            _answersRepository = answersRepository;
            _mapper = mapper;
            _questionsRepository = questionsRepository;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<UserQuizAnswer>> SetAnswer(UserQuizAnswerDTO userQuizAnswerDTO)
        {
            UserQuizAnswer userQuizAnswer = new UserQuizAnswer{UserAnswer = userQuizAnswerDTO.UserAnswer,
                QuestionId = userQuizAnswerDTO.QuestionId};

            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Name)?.Value);
            if (user == null) return NotFound("Could not find user");

            var alreadyAnswer = await _answersRepository.GetUserAnswerAsync(user.Id, userQuizAnswerDTO.QuestionId);
            if(alreadyAnswer != null) return BadRequest("You have already answered this question");

            userQuizAnswer.PlayerId = user.Id;

            var question = await _questionsRepository.GetQuestionAsync(userQuizAnswerDTO.QuestionId);
            if (question == null) return NotFound("Could not find question");

            if (question.Answer.ToLower() == userQuizAnswerDTO.UserAnswer.ToLower())
            {
                userQuizAnswer.IsAnswerCorrect = true;
            }
            else 
            {
                userQuizAnswer.IsAnswerCorrect = false;
            }

            var result = await _answersRepository.SetUserAnswerAsync(userQuizAnswer);
            if (result == null) return BadRequest("Something went wrong adding the answer to the database");

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserQuizAnswersDTO>>> GetUserAnswers()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Name)?.Value);

            var result = await _answersRepository.GetUserAnswerAllAsync(user.Id);
            if(!result.Any()) return NotFound(_mapper.Map<IReadOnlyList<UserQuizAnswersDTO>>(result));

            return Ok(_mapper.Map<IReadOnlyList<UserQuizAnswersDTO>>(result));
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteAnswers()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Name)?.Value);
            if (user == null) return NotFound("Could not find user");

            var result = await _answersRepository.DeleteAnswersAsync(user.Id);
            if (result) return BadRequest("Something went wrong deleting the answers");
            return Ok();
        }
    }
}