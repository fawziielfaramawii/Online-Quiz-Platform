﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Dtos.Admin.StudentDtos
{
    public class StudentAddDto
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int Age { get; set; }
        public string ImgUrl { get; set; }
        public string Gender { get; set; }

        public string Adress { get; set; }



    }
}
