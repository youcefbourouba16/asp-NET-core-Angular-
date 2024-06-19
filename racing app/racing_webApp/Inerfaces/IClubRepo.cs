using racing_webApp.Models;
using racing_webApp.ViewModels;

namespace racing_webApp.Inerfaces
{
    public interface IClubRepo
    {
        Task<IEnumerable<Club>> GetAll();
        Task<Club> GetByIdAsyc(int id);
        Task<IEnumerable<Club>> GetClubsByCity(String city);

        bool Add(Club club);
        bool Add(CreateClubViewModel club);
        bool Delete(Club club);
        bool Update(Club club);
        bool Save();
    }
}
