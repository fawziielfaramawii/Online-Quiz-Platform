using OnlineQuiz.DAL.Data.DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.Base
{
    public class Repository<T, U> : IRepository<T, U> where T : class
    {
        private readonly QuizContext _context;
       

        public Repository(QuizContext context)
        {
            _context = context;
            
        }

        // Get all entities as IQueryable for flexible querying
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        // Get a single entity by its ID (generic type for ID)
        public T GetById(U id)
        {
            return _context.Set<T>().Find(id);
        }

        // Add a new entity
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        // Update an existing entity
        public void Update(T entity)
        {
      
            _context.SaveChanges();
        }

        // Delete an entity by ID (generic type for ID)
        public void DeleteById(U id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
