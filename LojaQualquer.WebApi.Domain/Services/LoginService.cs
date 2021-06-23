using LojaQualquer.WebApi.Domain.Interfaces.Repositories;
using LojaQualquer.WebApi.Domain.Interfaces.Services;
using LojaQualquer.WebApi.Domain.Models;
using LojaQualquer.WebApi.Domain.Models.Request;
using LojaQualquer.WebApi.Domain.Models.Response;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthorizeService _authorizeService;

        public LoginService(IUserRepository userRepository, IAuthorizeService authorizeService)
        {
            _userRepository = userRepository;
            _authorizeService = authorizeService;
        }

        public async Task<TokenResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmail(request.Email);

            if (user == null) throw new BusinessException("Usuário não encontrado.");

            if (!_authorizeService.VerifyPassword(user, request.Password))
                throw new BusinessException("A senha informada está incorreta.");

            return new TokenResponse
            {
                Name = user.Name, 
                Token = _authorizeService.GenerateToken(user)
            };
        }
    }
}