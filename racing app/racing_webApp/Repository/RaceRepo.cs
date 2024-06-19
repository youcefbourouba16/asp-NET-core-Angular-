using Microsoft.EntityFrameworkCore;
using racing_webApp.Data;
using racing_webApp.Inerfaces;
using racing_webApp.Models;

namespace racing_webApp.Repository
{
    public class RaceRepo : IRaceRepo
    {
        private readonly Db_context _context;

        public RaceRepo(Db_context context)
        {
            _context = context;
        }
        public bool Add(Race race)
        {
            _context.Add(race);
            return Save();


        }

        public bool Delete(Race race)
        {
            _context.Remove(race);
            return Save();

        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race> GetByIdAsyc(int id)
        {
            return await _context.Races.Include(a=>a.Address).FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IEnumerable<Race>> GetClubsByCity(string city)
        {
            return await _context.Races
                                 .Include(c => c.Address) // Include Address if it's a separate entity
                                 .Where(c => c.Address.City.Contains(city))
                                 .ToListAsync();
        }





        public bool Update(Race race)
        {
            _context.Update(race);
            return Save();

        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
