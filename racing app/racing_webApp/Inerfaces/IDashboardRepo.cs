using racing_webApp.Data;
using racing_webApp.Models;

namespace racing_webApp.Inerfaces
{
    public interface IDashboardRepo
    {
        Task<List<Club>> GetAllUserClubs();
        Task<List<Race>> GetAllUserRaces();
    }
}
