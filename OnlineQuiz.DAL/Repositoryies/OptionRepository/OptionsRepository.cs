using OnlineQuiz.DAL.Data.DBHelper;
using OnlineQuiz.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.OptionRepository
{
    public class OptionsRepository : IOptionsRepository
    {
        private readonly QuizContext _context;

        public OptionsRepository(QuizContext context)
        {
            _context = context;
        }

        public IQueryable<Option> GetAll()
        {
            return _context.Set<Option>().AsQueryable();
        }

        public Option GetById(int id)
        {
            return _context.Set<Option>().Find(id);
        }

        public void Add(Option entity)
        {
            _context.Set<Option>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Option entity)
        {
            _context.Set<Option>().Update(entity);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var option = GetById(id);
            if (option != null)
            {
                _context.Set<Option>().Remove(option);
                _context.SaveChanges();
            }
        }
    }
}
