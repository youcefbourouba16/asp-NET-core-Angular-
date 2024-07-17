using Microsoft.EntityFrameworkCore;
using racing_webApp.Data;
using racing_webApp.Inerfaces;
using racing_webApp.Models;

namespace racing_webApp.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly Db_context _dbContext;
        public UserRepo(Db_context dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(AppUser user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(AppUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public Task<AppUser> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
