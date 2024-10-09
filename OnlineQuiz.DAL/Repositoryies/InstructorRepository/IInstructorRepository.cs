using OnlineQuiz.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.InstructorRepository
{
    public interface IInstructorRepository
    {

        // crud opreation on quiz (add - delete - edit - get)
        IEnumerable<Quizzes> GetAllQuizzes(string id);

        // get by  name  Quizzes 
        IEnumerable<Quizzes> GetQuizzesName(string name);


        // add Quizzes
        public void AddQuizzes(Quizzes Quizzes);
        // edit Quizzes
        public void UpdateQuizzes(Quizzes Quizzes);

        // delete Quizzes
        public void DeleteQuizzes(Quizzes Quizzes);



        // crud opreation on qustion on quiz (add - delete - edit - get)

        IEnumerable<Questions> GetAllQuestionsOfQuiz(int id);

        // add Quizzes
        //public void AddQuestions(Questions Question);
        Task AddQuestionAsync(int quizId, Questions question); // Method to add question to quiz
        // edit Quizzes
        public void UpdateQuestions(Questions Question);

        // delete Quizzes
        public void DeleteQuestions(Questions Question);

        // add student and delete to  quiz like sup 

        Task AddStudentToInstructorAsync(string studentId, string instructorId); // add student from instructor
        Task RemoveStudentFromInstructorAsync(string studentId, string instructorId); // Remove student from instructor

        // save in database
        void savechanges();
    }
}
