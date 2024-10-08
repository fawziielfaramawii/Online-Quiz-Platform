using OnlineQuiz.DAL.Data.DBHelper;
using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.AttemptRepository
{
    public class AttemptRepository : IRepository<Attempts, int>, IAttemptRepository
    {
        private readonly QuizContext _context;

        public AttemptRepository(QuizContext context)
        {
            _context = context;
        }


        public void DeleteById(int id)
        {
            Attempts attempts = _context.attempts.FirstOrDefault(a => a.Id == id);
            _context.attempts.Remove(attempts);
            _context.SaveChanges();
        }

        public IQueryable<Attempts> GetAll()
        {
            return _context.attempts;
        }

        public Attempts GetById(int id)
        {
            Attempts attempts = _context.attempts.FirstOrDefault(a => a.Id == id);
            return attempts;
        }

        public void Add(Attempts attempt)
        {
            throw new NotImplementedException();
        }

        public void Update(Attempts entity)
        {
            _context.SaveChanges();
        }

        public void StartQuizAttempt(Attempts attempt)
        {
            _context.attempts.Add(attempt);
            _context.SaveChanges();
        }

        public void SubmitQuizAttempt(int attemptId, List<Answers> submittedAnswers)
        {
            Attempts? attempt = _context.attempts.FirstOrDefault(a => a.Id == attemptId);

            if (attempt == null)
                throw new Exception("Attempt not found");

            foreach (Answers answer in submittedAnswers)
            {
                var answers = new Answers
                {
                    AttemptId = attemptId,
                    QuestionId = answer.QuestionId,
                    SubmittedAnswer = answer.SubmittedAnswer,
                    IsCorrect = _context.questions.FirstOrDefault(q => q.Id == answer.QuestionId)
                    ?.CorrectAnswer == answer.SubmittedAnswer
                };

                _context.answers.Add(answers);
            }
            attempt.EndTime = DateTime.Now;
            attempt.Score = CalculateScore(attemptId);
            _context.SaveChanges();
        }

        public Attempts GetResults(int Id)
        {
            Attempts? attempt = _context.attempts
           .Include(a => a.Quiz)
           .Include(a => a.Answers)
          .FirstOrDefault(a => a.Id == Id);

            return attempt!;
        }

        public IEnumerable<Attempts> GetUserAttempts(string studentId)
        {
            return _context.attempts
            .Where(a => a.StudentId == studentId)
            .Include(a => a.Quiz)
            .ToList();
        }
       private double CalculateScore(int attemptId)
        {
            int correctAnswers = _context.answers
                .Where(a => a.AttemptId == attemptId && a.IsCorrect)
                .Count();

            int totalQuestions = _context.answers
                .Where(a => a.AttemptId == attemptId)
                .Count();

            if (totalQuestions == 0)
            {
                return 0;
            }

            return (double)correctAnswers / totalQuestions * 100;
        }

        public Student GetStudent(string studID)
        {
            Student student = _context.Students.Find(studID);
            return student;
        }

        public Quizzes GetQuizzes(int quizID)
        {
            Quizzes quizzes = _context.quizzes.FirstOrDefault(q => q.Id == quizID);
            return quizzes;
        }
    }
}
