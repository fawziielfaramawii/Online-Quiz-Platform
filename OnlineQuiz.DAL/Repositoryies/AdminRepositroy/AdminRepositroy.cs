using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OnlineQuiz.DAL.Data.DBHelper;
using OnlineQuiz.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.AdminRepositroy
{
    public class AdminRepositroy : IAdminRepositroy
    {
        private readonly QuizContext _Context;

        public AdminRepositroy(QuizContext QuizContext)
        {
            _Context = QuizContext;
        }
        public void AddInstructor(Instructor Instructor)
        {
            _Context.SaveChanges();
        }

        public void AddStudent(Student student)
        {
            _Context.SaveChanges();
        }


        
        public void DeleteInstructor(Instructor Instructor)
        {
            _Context.Remove(Instructor);
             SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _Context.Remove(student);
            SaveChanges();
        }

        public IEnumerable<Instructor> GetAllInstructo()
        {
            return _Context.Instructors.ToList();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _Context.Students.ToList();
        }

        public Instructor GetInstructorById(int id)
        {
            return _Context.Instructors.FirstOrDefault(Key => Key.Id == id.ToString());
        }

        public Instructor GetInstructorByName(string name)
        {
            return _Context.Instructors.FirstOrDefault(Key => Key.UserName == name);

        }

        public Student GetStudentById(int id)
        {
            return _Context.Students.FirstOrDefault(Key => Key.Id == id.ToString());

        }

        public Student GetStudentByName(string name)
        {
            return _Context.Students.FirstOrDefault(Key => Key.UserName == name.ToString());

        }

      
      

        public void UpdateInstructor(Instructor Instructor)
        {
            SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            SaveChanges();
        }




        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public async Task ApproveInstructorAsync(int InstructorId)
        {
            var instructor = await _Context.Instructors.FirstOrDefaultAsync(key=> key.Id == InstructorId.ToString());
            if (instructor != null)
            {
                instructor.Status = ApprovalStatus.Approved;
                _Context.Update(instructor);
                await _Context.SaveChangesAsync();
            }
        }


        public async Task DenyInstructorAsync(int InstructorId)
        {
            var instructor = await _Context.Instructors.FirstOrDefaultAsync(key => key.Id == InstructorId.ToString());
            if (instructor != null)
            {
                instructor.Status = ApprovalStatus.Denied;
                _Context.Update(instructor);
                await _Context.SaveChangesAsync();
            }
        }



        public async Task BanUserAsync(int UserId)
        {
            var users = await _Context.users.FirstOrDefaultAsync(key => key.Id == UserId.ToString());
            if (users != null)
            {
                users.IsBanned = true;
                _Context.Update(users);
                await _Context.SaveChangesAsync();
            }
        }

        public async Task UnbanUserAsync(int UserId)
        {
            var users = await _Context.users.FirstOrDefaultAsync(key => key.Id == UserId.ToString());
            if (users != null)
            {
                users.IsBanned = false;
                _Context.Update(users);
                await _Context.SaveChangesAsync();
            }
        }
    }
}
