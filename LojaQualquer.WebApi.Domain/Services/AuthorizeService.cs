using LojaQualquer.WebApi.Domain.Entities;
using LojaQualquer.WebApi.Domain.Interfaces.Services;
using LojaQualquer.WebApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace LojaQualquer.WebApi.Domain.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly AuthorizeConfig _authorizeConfig;

        public AuthorizeService(AuthorizeConfig authorizeConfig)
        {
            _authorizeConfig = authorizeConfig;
        }

        public string HashPassword(User user, string password)
        {
            return new PasswordHasher<User>().HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string password)
        {
            var passwordVerificationResult =
                new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, password);

            return passwordVerificationResult == PasswordVerificationResult.Success;
        }

        public string GenerateToken(User user)
        {
            var claims = new ClaimsIdentity(
                new GenericIdentity(user.Email, "Email"),
                new[]
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name)
                }
            );

            var jwtSecurity = new JwtSecurityTokenHandler();
                
            var securityToken = jwtSecurity.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _authorizeConfig.Issuer,
                Audience = _authorizeConfig.Audience,
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authorizeConfig.Key)),
                        SecurityAlgorithms.HmacSha256Signature),
                Subject = claims,
                Expires = DateTime.Now.AddDays(7)
            });

            return jwtSecurity.WriteToken(securityToken);
        }
    }
}