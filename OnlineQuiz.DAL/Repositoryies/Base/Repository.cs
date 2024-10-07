using OnlineQuiz.DAL.Data.DBHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.Base
{
<<<<<<< HEAD
    public class Repository<T,U> : IRepository<T,U> where T : class
=======
    public class Repository<T, U> : IRepository<T, U> where T : class
>>>>>>> 319a13ab30cffa39590e076416bcc03811e778b8
    {
        private readonly QuizContext _context;
       

        public Repository(QuizContext context)
        {
            _context = context;
<<<<<<< HEAD
        }  
=======
            
        }
>>>>>>> 319a13ab30cffa39590e076416bcc03811e778b8

        // Get all entities as IQueryable for flexible querying
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

<<<<<<< HEAD
=======
        // Get a single entity by its ID (generic type for ID)
>>>>>>> 319a13ab30cffa39590e076416bcc03811e778b8
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
<<<<<<< HEAD
            _context.SaveChanges();
        }

=======
      
            _context.SaveChanges();
        }

        // Delete an entity by ID (generic type for ID)
>>>>>>> 319a13ab30cffa39590e076416bcc03811e778b8
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
