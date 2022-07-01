using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SysManager.Admin.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
	[Route("api/v{version:apiVersion}/[controller]")]
    public class UnitController
    {
        [HttpPost()]
		public async Task<string> Post()
		{
			return "teste";
		}
    }
}