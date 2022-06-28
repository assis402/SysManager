using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Helpers;
using SysManager.Application.Services;

namespace SysManager.API.Admin.Controllers
{
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class AccountController
	{
		readonly UserService _service;

		public AccountController(UserService service)
		{
			_service = service;
		}

		[HttpPost("create-account")]
		public async Task<IActionResult> Post([FromBody] UserPostRequest request)
		{
			var response = await _service.PostAsync(request);
			return Utils.Convert(response);
		}

		[HttpPost("recovery-account")]
		public async Task<IActionResult> Put([FromBody] UserPutRequest request)
		{
			var response = await _service.PutAsync(request);
			return Utils.Convert(response);
		}
	}
}