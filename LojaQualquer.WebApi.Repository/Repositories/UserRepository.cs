using LojaQualquer.WebApi.Domain.Entities;
using LojaQualquer.WebApi.Domain.Interfaces.Repositories;
using LojaQualquer.WebApi.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EntityContext context) : base(context) { }

        public async Task<User> GetByEmail(string email)
        {
            return await Entity.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}