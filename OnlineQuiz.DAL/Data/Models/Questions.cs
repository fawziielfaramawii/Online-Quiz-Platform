using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Data.Models
{
    public abstract class Questions                // Table By Concrete
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public abstract string CorrectAnswer { get; set; }


        // For Quiz
        public int QuizId { get; set; }
        public Quizzes Quiz { get; set; }

        // for Answer
        public ICollection<Answers> Answers { get; set; } = new HashSet<Answers>();
    }



    public class TrueAndFalseQuestion : Questions
    {
        [Required]
        public bool IsTrue { get; set; }

        //Implmentation of Abstract CorrectAnswer
        public override string CorrectAnswer
        {
            get => IsTrue ? "True" : "False";
            set => IsTrue = value.ToLower() == "true";
        }
    }



    public class MultipleChoicesQuestion : Questions
    {
        [Required]
        public int  CorrectOptionId { get; set; }

        //Implmentation of Abstract CorrectAnswer
        public override string CorrectAnswer 
        {
            get
            {
                
                var correctOption = Options.FirstOrDefault(o => o.OptionId == CorrectOptionId);
                return correctOption != null ? correctOption.OptionText : "Answer not found";
            }
            set
            {
                CorrectOptionId = GetOptionIdByOptionText(value);
            }


        }

        public int GetOptionIdByOptionText(string optionText)
        {
            var option = Options.FirstOrDefault(o => o.OptionText.Equals(optionText, StringComparison.OrdinalIgnoreCase));

            if (option != null)
            {
                return option.OptionId;
            }

            throw new ArgumentException($"Option with text '{optionText}' does not exist.");
        }


        // for Option
        public ICollection<Option> Options { get; set; } = new HashSet<Option>();
    }

}

