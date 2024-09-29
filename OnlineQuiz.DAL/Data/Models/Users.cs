
using Microsoft.AspNetCore.Identity;
using OnlineQuiz.DAL.Data.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Data.Models
{
    //Table By Hiercay
    public enum Type
    {
        Student= 1 ,
        Instructor = 2,
        Admin = 3
    }
        


    

    public class Users : IdentityUser
    {


  
        [Range(5, 120)]
        public int Age { get; set; }

        public string Gender { get; set; }

        public string Adress { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImgUrl { get; set; }
        
        public Type UserType { get; set; }

      

   
    }

    public class Student:Users
    {
        public string  Grade { get; set; }
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        //Student With Attempts
        public ICollection<Attempts> Attempts { get; set; } = new HashSet<Attempts>();


    }


    public class Instructor : Users
    {

        public bool InstructorIsApproved { get; set; } = false;
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        //  Instructor with Quizzes
        public ICollection<Quizzes> quizzes { get; set; } = new HashSet<Quizzes>();

    }





}

