using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.BLL.Dtos.Quiz;
using OnlineQuiz.BLL.Managers.Quiz;
using static OnlineQuiz.BLL.Dtos.Quiz.QuizDto;

namespace OnlineQuiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizManager _quizManager;

        public QuizController(IQuizManager quizManager)
        {
            _quizManager = quizManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<QuizDto>> GetAllQuizzes()
        {
            var quizzes = _quizManager.GetAllQuizzes();
            return Ok(quizzes.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<QuizDto> GetQuizById(int id)
        {
            var quiz = _quizManager.GetQuizById(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }

        [HttpPost]
        public ActionResult<QuizDto> AddQuiz([FromBody] CreatQuizDTO quizDto)
        {
            if (quizDto == null)
            {
                return BadRequest("Quiz data is null.");
            }

            var createdQuiz = _quizManager.AddQuiz(quizDto);
            return Ok(quizDto); ;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQuiz(int id, [FromBody] QuizDto quizDto)
        {
            if (id != quizDto.Id)
            {
                return BadRequest("Quiz ID dont match.");
            }

            _quizManager.UpdateQuiz(quizDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuiz(int id)
        {
            _quizManager.DeleteQuiz(id);
            return NoContent();
        }

        [HttpGet("track/{trackId}")]
        public ActionResult<IEnumerable<QuizDto>> GetQuizzesByTrackId(int trackId)
        {
            var quizzes = _quizManager.GetQuizzesByTrackId(trackId);
            return Ok(quizzes.ToList());
        }
    }
}
