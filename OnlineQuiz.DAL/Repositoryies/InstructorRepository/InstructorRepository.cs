using Microsoft.EntityFrameworkCore;
using OnlineQuiz.DAL.Data.DBHelper;
using OnlineQuiz.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.InstructorRepository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly QuizContext _context;

        public InstructorRepository(QuizContext context)
        {
            _context = context;
        }




        public void AddQuizzes(Quizzes Quizzes)
        {
            _context.Add(Quizzes);
            savechanges();

        }

        public void DeleteQuizzes(Quizzes Quizzes)
        {
            _context.Remove(Quizzes);
            savechanges();
        }

        public IEnumerable<Quizzes> GetAllQuizzes(string id)
        {
            return _context.quizzes.Where(x => x.InstructorId == id);
        }

        public IEnumerable<Quizzes> GetQuizzesName(string name)
        {
            return _context.quizzes.Where(x => x.Tittle == name);
        }

        

        public void UpdateQuizzes(Quizzes Quizzes)
        {

            savechanges();
        }
        // ------------------------------------------------------------------------------



        public IEnumerable<Questions> GetAllQuestionsOfQuiz(int id)
        {
            return _context.questions.Where(x => x.QuizId == id);
        }

        public async Task AddQuestionAsync(int quizId, Questions question)
        {
            var quiz = await _context.Set<Quizzes>().Include(q => q.Questions)
                                                .FirstOrDefaultAsync(q => q.Id == quizId);

            if (quiz == null)
            {
                throw new Exception("Quiz not found");
            }

            quiz.Questions.Add(question); // Add the new question to the quiz
            await _context.SaveChangesAsync(); // Save changes to the database
        }


        public void UpdateQuestions(Questions Question)
        {
            savechanges();
        }

        public void DeleteQuestions(Questions Question)
        {
            _context.Remove(Question);
            savechanges();
        }
        //---------------------------
        public async Task AddStudentToInstructorAsync(string studentId, string instructorId)
        {
            var student = await _context.Students.FindAsync(studentId);
            var instructor = await _context.Instructors.FindAsync(instructorId);

            if (student == null || instructor == null)
                throw new Exception("Student or Instructor not found");

            var studentInstructor = new StudentInstructor
            {
                StudentId = studentId,
                InstructorId = instructorId
            };

            _context.StudentInstructors.Add(studentInstructor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveStudentFromInstructorAsync(string studentId, string instructorId)
        {
            var studentInstructor = await _context.StudentInstructors
                .FirstOrDefaultAsync(si => si.StudentId == studentId && si.InstructorId == instructorId);

            if (studentInstructor == null)
            {
                throw new Exception("The relationship does not exist");
            }

            _context.StudentInstructors.Remove(studentInstructor);
            await _context.SaveChangesAsync(); 
        }




        // ------------------------------------------------------------------------------
        public void savechanges()
        {
            _context.SaveChanges();
        }

      



 
    }
}
