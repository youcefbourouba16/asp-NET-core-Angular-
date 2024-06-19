using racing_webApp.Models;

namespace racing_webApp.Inerfaces
{
    public interface IRaceRepo
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByIdAsyc(int id);
        Task<IEnumerable<Race>> GetClubsByCity(String city);
        bool Add(Race race);
        bool Delete(Race race);
        bool Update(Race race);
        bool Save();
    }
}
