 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.Base
{
<<<<<<< HEAD
    public interface IRepository<T,U> where T : class
    {
        // Get all entities
        IEnumerable<T> GetAll();

        // Get a single entity by its ID
        T GetById(U id);

        // Add a new entity
=======
    public interface IRepository<T, U> where T : class
    {
       
        IQueryable<T> GetAll();
        T GetById(U id);
>>>>>>> 319a13ab30cffa39590e076416bcc03811e778b8
        void Add(T entity);
        void Update(T entity);
<<<<<<< HEAD

        // Delete an entity by ID
        void DeleteById(U id);


=======
        void DeleteById(U id);
>>>>>>> 319a13ab30cffa39590e076416bcc03811e778b8
    }
}
