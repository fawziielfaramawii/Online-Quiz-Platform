using OnlineQuiz.DAL.Data.DBHelper;
using OnlineQuiz.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.AnswerRepository
{
    public class AnswerRepository : IAnswerRepository
    {
     
        private readonly QuizContext _context;

        public AnswerRepository(QuizContext context)
        {
            _context = context;
        }
        public void AddAnswer(Answers answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public List<Answers> GetAnswersByAttemptId(int attemptId)
        {
            return _context.Answers
                .Where(a => a.AttemptId == attemptId)
                .ToList();
        }
        public String getcorrectanswer(Answers answer)
        {
            var ques = _context.questions.Where(a => a.Id == answer.QuestionId);
            var x = ques.Select(a => a.CorrectAnswer);
            return x.ToString();
        }

        public bool CheckCorrectAnswer(int questionId, string submittedAnswer)
        {
            var question = _context.Questions.Find(questionId);
            return question != null && question.CorrectAnswer.Equals(submittedAnswer, StringComparison.OrdinalIgnoreCase);
        }

        public List<string> GetCorrectAnswersForQuiz(int quizId)
        {
            return _context.Questions
                .Where(q => q.QuizId == quizId)
                .Select(q => q.CorrectAnswer)
                .ToList();
        }

       
    }
}
