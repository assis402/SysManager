using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Helpers;
using SysManager.Application.Services;
using System.Threading.Tasks;

namespace SysManager.API.Admin.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController
    {
        private readonly UserService _service;

        public AccountController(UserService service) => _service = service;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserPostLoginRequest request) => (await _service.PostLoginAsync(request)).Convert();

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] UserPostRequest request) => (await _service.PostAsync(request)).Convert();

        [HttpPut("recovery-account")]
        public async Task<IActionResult> Put([FromBody] UserPutRequest request) => (await _service.PutAsync(request)).Convert();
    }
}