 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.Base
{
    public interface IRepository<T> where T : class
    {
        // Get all entities
        IEnumerable<T> GetAll();

        // Get a single entity by its ID
        T GetById(int id);

        // Add a new entity
        void Add(T entity);

        // Update an existing entity
        void Update(T entity);

        // Delete an entity by ID
        void DeleteById(int id);


    }
}
