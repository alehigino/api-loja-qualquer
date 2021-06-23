using LojaQualquer.WebApi.Domain.Interfaces.Services;
using LojaQualquer.WebApi.Domain.Models.Request;
using LojaQualquer.WebApi.Domain.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Controllers
{
    /// <summary>
    /// Login Controller
    /// </summary>
    [Route("api/login")]
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loginService"></param>
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Check email and password and return token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(TokenResponse))]
        [ProducesResponseType(400, Type = typeof(ResponseError))]
        [ProducesResponseType(500, Type = typeof(ResponseError))]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return Ok(await _loginService.LoginAsync(request));
        }
    }
}
