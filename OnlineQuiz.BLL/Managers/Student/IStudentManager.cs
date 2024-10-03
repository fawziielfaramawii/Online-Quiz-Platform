using OnlineQuiz.BLL.Dtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Managers.Student
{
    public interface IStudentManager
    {
        IEnumerable<StudentReadDto> GetAll();

        // Get a single entity by its ID
        StudentReadDto GetById(int id);

        // Add a new entity
        void Add(StudentAddDto entity);

        // Update an existing entity
        void Update(StudentUpdateDto entity);

        // Delete an entity by ID
        void DeleteById(int id);
        //Get list of student BY grade
        IEnumerable<StudentReadDto> GetStudentsByGrade(string grade);
    }
}
