using Microsoft.EntityFrameworkCore;
using OnlineQuiz.DAL.Data.DBHelper;
using OnlineQuiz.DAL.Data.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.DAL.Repositoryies.TrackRepository
{
    public class TrackRepository :ITrackRepository
    {
        private readonly QuizContext _context;

        public TrackRepository(QuizContext context)
        {
            _context = context;
        }

        public IEnumerable<Tracks> GetAll()
        {
            return _context.Set<Tracks>().ToList();
        }

        public Tracks GetById(int id)
        {
            return _context.Set<Tracks>().Find(id);
        }

        public void Add(Tracks track)
        {
            _context.Set<Tracks>().Add(track);
            _context.SaveChanges();
        }

        public void Update(Tracks track)
        {
            _context.Entry(track).State = EntityState.Modified; // Mark entity as modified
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var track = _context.Set<Tracks>().Find(id);
            if (track != null)
            {
                _context.Set<Tracks>().Remove(track);
                _context.SaveChanges();
            }
        }

    }
}
