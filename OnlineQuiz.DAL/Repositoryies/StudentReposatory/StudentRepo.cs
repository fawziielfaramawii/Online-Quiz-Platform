using OnlineQuiz.DAL.Data.DBHelper;
using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.StudentReposatory
{
    public class StudentRepo : Repository<Student> , IStudentRepo
    {
        private readonly QuizContext _quizContext;

        public StudentRepo(QuizContext quizContext):base(quizContext)
        {
            _quizContext = quizContext;
        }

        public  IEnumerable<Student> GetStudentsByGrade(string grade)
        {
            return  _quizContext.Students
                                .Where(s => s.Grade == grade)
                                .ToList();
        }
    }
}
