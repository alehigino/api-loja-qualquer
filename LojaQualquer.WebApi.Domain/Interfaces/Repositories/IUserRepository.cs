using LojaQualquer.WebApi.Domain.Entities;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
    }
}