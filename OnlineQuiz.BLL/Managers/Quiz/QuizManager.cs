using AutoMapper;
using OnlineQuiz.BLL.Dtos.Quiz;
using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.Base;
using OnlineQuiz.DAL.Repositoryies.QuizRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineQuiz.BLL.Dtos.Quiz.QuizDto;

namespace OnlineQuiz.BLL.Managers.Quiz
{
    public class QuizManager : IQuizManager
    {
        private readonly IRepository<Quizzes, int> _quizRepository;
        private readonly IQuizRepository quizRepository1;
        private readonly IMapper _mapper;

        public QuizManager(IRepository<Quizzes, int> quizRepository,IQuizRepository quizRepository1, IMapper mapper)
        {
            _quizRepository = quizRepository;
            this.quizRepository1 = quizRepository1;
            _mapper = mapper;
        }

        public IQueryable<QuizDto> GetAllQuizzes()
        {
            return _quizRepository.GetAll().Select(quiz => _mapper.Map<QuizDto>(quiz));
        }

        public QuizDto GetQuizById(int id)
        {
            var quiz = _quizRepository.GetById(id);
            return _mapper.Map<QuizDto>(quiz);
        }

        public CreatQuizDTO AddQuiz(CreatQuizDTO quizDto)
        {
            var quiz = _mapper.Map<Quizzes>(quizDto);
            _quizRepository.Add(quiz);
            return _mapper.Map<CreatQuizDTO>(quiz); // Return the mapped QuizDto
        }

        public void UpdateQuiz(QuizDto quizDto)
        {
            var quiz = _mapper.Map<Quizzes>(quizDto);
            _quizRepository.Update(quiz); 
        }

        public void DeleteQuiz(int id)
        {
            _quizRepository.DeleteById(id);
        }

        public IQueryable<QuizDto> GetQuizzesByTrackId(int trackId)
        {
            return _quizRepository.GetAll()
                                  .Where(q => q.TracksId == trackId)
                                  .Select(quiz => _mapper.Map<QuizDto>(quiz));
        }
        public IQueryable<FinalQuizDTO> GetQuizzesWithQuestionsAndOptions()
        {
            return quizRepository1.GetQuizzesWithQuestions() // Use the new method
                       .Select(quiz => _mapper.Map<FinalQuizDTO>(quiz));
        }
        public FinalQuizDTO GetQuizByIdWithQuestions(int id)
        {
            var quiz = quizRepository1.GetQuizByIdWithQuestions(id);
            return _mapper.Map<FinalQuizDTO>(quiz);
        }
    }
}
