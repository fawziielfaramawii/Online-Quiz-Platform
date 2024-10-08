using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.AttemptRepository;
namespace OnlineQuiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttemptController : ControllerBase
    {
        private readonly IAttemptRepository _attemptRepository;

        public AttemptController(IAttemptRepository attemptRepository)
        {
            _attemptRepository = attemptRepository;
        }

        [HttpPost("StartQuizAttempt")]
        public IActionResult StartQuizAttempt(int quizId, string studID)
        {
            Quizzes quizzes = _attemptRepository.GetQuizzes(quizId);
            Student student = _attemptRepository.GetStudent(studID);

            if (quizzes != null && student != null)
            {
                Attempts attempt = new Attempts
                {
                    QuizId = quizId,
                    StartTime = DateTime.Now,
                    StateForExam = "Started",
                    StudentId = studID
                };

                _attemptRepository.StartQuizAttempt(attempt);

                return Ok(new { attempt.Id, message = "Quiz attempt started successfully" });
            }

            else
            {
                return BadRequest("Erorr");
            }
        }

        [HttpPost("SubmitQuizAttempt")]
        public IActionResult SubmitQuizAttempt(int attemptId, List<Answers> submittedAnswers)
        {
            _attemptRepository.SubmitQuizAttempt(attemptId, submittedAnswers);
            return Ok(new { message = "Quiz attempt submitted successfully" });
        }

        [HttpGet("GetResults")]
        public IActionResult GetResults(int attemptId)
        {
            Attempts result = _attemptRepository.GetResults(attemptId);

            if (result == null)
                return NotFound("Attempt not found");

            return Ok(new
            {
                result.Quiz.Tittle,
                result.StartTime,
                result.EndTime,
                result.Score,
                Answers = result.Answers.Select(a => new
                {
                    a.SubmittedAnswer,
                    a.IsCorrect,
                })
            });
        }

        [HttpGet("GetUserAttempts")]
        public IActionResult GetUserAttempts(string studentId)
        {
            IEnumerable<Attempts> attempts = _attemptRepository.GetUserAttempts(studentId);

            if (attempts == null || !attempts.Any())
                return NotFound("No attempts found for the user");

            return Ok(attempts);
        }
    }
}
