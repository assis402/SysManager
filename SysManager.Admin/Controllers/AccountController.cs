using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Helpers;

namespace SysManager.API.Admin.Controllers
{
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class AccountController
	{
		public AccountController()
		{
		}

		[HttpPost("account-create")]
		public async Task<ResultData> Post(UserPostRequest request)
		{
			var response = Utils.SuccessData("Reposta do método", true);
			return response;
		}
	}
}