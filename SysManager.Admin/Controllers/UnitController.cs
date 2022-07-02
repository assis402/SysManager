using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Helpers;

namespace SysManager.Admin.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
    public class UnitController
    {
        public UnitController()
        {
        }
        
         [HttpPut]
        public async Task<IActionResult> Put([FromBody] UnityPutRequest request)
        {
            return Utils.Convert(new ResultData(true));
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Utils.Convert(new ResultData(true));
        }

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] UnityGetByFilterRequest request)
        {
            return Utils.Convert(new ResultData(true));
        }
        
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            return Utils.Convert(new ResultData(true));
        }
    }
}