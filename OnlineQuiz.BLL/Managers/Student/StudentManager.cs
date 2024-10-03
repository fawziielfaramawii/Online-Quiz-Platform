using OnlineQuiz.BLL.Dtos.StudentDtos;
using OnlineQuiz.DAL.Repositoryies.Base;
using OnlineQuiz.DAL.Repositoryies.StudentReposatory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Managers.Student
{
    public class StudentManager :IStudentManager
    {
        private readonly IStudentRepo _studentRepo;

        public StudentManager(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public void Add(StudentAddDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentReadDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentReadDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentReadDto> GetStudentsByGrade(string grade)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
