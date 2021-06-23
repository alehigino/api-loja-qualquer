using LojaQualquer.WebApi.Domain.Entities;

namespace LojaQualquer.WebApi.Domain.Interfaces.Services
{
    public interface IAuthorizeService
    {
        public string HashPassword(User user, string password);
        public bool VerifyPassword(User user, string password);
        string GenerateToken(User user);
    }
}