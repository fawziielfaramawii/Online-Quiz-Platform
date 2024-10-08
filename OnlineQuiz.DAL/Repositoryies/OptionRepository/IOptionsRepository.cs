using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.OptionRepository
{
    public interface IOptionsRepository : IRepository<Option, int>
    {
        // Additional methods can be defined here if needed
    }
}
