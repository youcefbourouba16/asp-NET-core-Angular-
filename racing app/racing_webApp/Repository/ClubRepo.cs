using Microsoft.EntityFrameworkCore;
using racing_webApp.Data;
using racing_webApp.Inerfaces;
using racing_webApp.Models;
using racing_webApp.ViewModels;
using System.Linq;

namespace racing_webApp.Repository
{
    public class ClubRepo : IClubRepo
    {
        private readonly Db_context _context;

        public ClubRepo(Db_context context)
        {
            _context = context;
        }
        

        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();

        }

        public async Task<IEnumerable<Club>> GetAll()
        {
           var m=  await _context.Clubs.Include(c=> c.Address).ToListAsync();
            return m;
        }

        public async Task<Club> GetByIdAsyc(int id)
        {
            return await _context.Clubs.Include(a=>a.Address).FirstOrDefaultAsync(c=> c.Id==id);
        }
        public async Task<IEnumerable<Club>> GetClubsByCity(string city)
        {
            return await _context.Clubs
                                 .Include(c => c.Address) // Include Address if it's a separate entity
                                 .Where(c => c.Address.City.Contains(city))
                                 .ToListAsync();
        }





        public bool Update(Club club)
        {
            _context.Update(club);
            return Save();

        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Add(CreateClubViewModel club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }
    }
}
