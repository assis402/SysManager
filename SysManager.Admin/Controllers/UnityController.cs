using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Helpers;
using SysManager.Application.Services;

namespace SysManager.Admin.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
    public class UnityController
    {
        private readonly UnityService _unityService;

        public UnityController(UnityService unityService) => _unityService = unityService;

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] UnityPostRequest request) => (await _unityService.PostAsync(request)).Convert();

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] UnityPutRequest request) => (await _unityService.PutAsync(request)).Convert();

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] UnityGetByFilterRequest request) => (await _unityService.GetByFilterAsync(request)).Convert();

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id) => (await _unityService.GetByIdAsync(id)).Convert();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) => (await _unityService.DeleteByIdAsync(id)).Convert();
    }
}