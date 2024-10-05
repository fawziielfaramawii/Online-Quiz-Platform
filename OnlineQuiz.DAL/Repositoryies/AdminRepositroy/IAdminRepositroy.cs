using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.AdminRepositroy
{
    public interface IAdminRepositroy //: //IRepository<Users>
    {

        // get all instractour or student 
        IEnumerable<Student> GetAllStudent();

        // get by id or name  instractour or student 
        Student GetStudentById(int id);
        Student GetStudentByName(string name);


        // add instractour or student 
        public void AddStudent(Student student);
        // edit instractour or student 
        public void UpdateStudent(Student student);

        // delete instractour or student 
        public void DeleteStudent(Student student);



        // get all instractour 
        IEnumerable<Instructor> GetAllInstructo();

        // get by id or name instractour) 
        Instructor GetInstructorById(int id);
        Instructor GetInstructorByName(string name);


        // add instractour  
        public void AddInstructor(Instructor Instructor);
        // edit instractour 
        public void UpdateInstructor(Instructor Instructor);

        // delete instractour 
        public void DeleteInstructor(Instructor Instructor);





        // Approve and deny instractour after login only accses for admin

        Task ApproveInstructorAsync(int instructorId);
        Task DenyInstructorAsync(int instructorId);

        // ban and un ban users accses for admin
        Task BanUserAsync(int studentId);
        Task UnbanUserAsync(int studentId);


        // App details instractour 


        // role admin only acsses

        void SaveChanges();
    }
}
