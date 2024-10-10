using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.BLL.Managers.Answer;
using OnlineQuiz.BLL.Managers.Base;
using OnlineQuiz.BLL.Managers.Track;
using OnlineQuiz.DAL.Data.DBHelper;

namespace OnlineQuiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswersManager _answerManager;

        public AnswersController(IAnswersManager answerManager)
        {
            _answerManager = answerManager;
        }

        [HttpPost("submit")]
        public IActionResult SubmitAnswer([FromBody] SubmitAnswerRequest request)
        {
            _answerManager.SubmitAnswer(request.AttemptId, request.QuestionId, request.SubmittedAnswer);
            return Ok(new { message = "Answer submitted successfully." });
        }

        [HttpGet("{attemptId}")]
        public IActionResult GetUserAnswers(int attemptId)
        {
            var answers = _answerManager.GetUserAnswers(attemptId);
            return Ok(answers);
        }

        [HttpGet("correct/{quizId}")]
        public IActionResult GetCorrectAnswers(int quizId)
        {
            var correctAnswers = _answerManager.GetCorrectAnswers(quizId);
            return Ok(correctAnswers);
        }
    }

    public class SubmitAnswerRequest
    {
        public int AttemptId { get; set; }
        public int QuestionId { get; set; }
        public string SubmittedAnswer { get; set; }
    }

}

