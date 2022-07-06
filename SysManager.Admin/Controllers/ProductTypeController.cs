using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.ProductType.Request;
using SysManager.Application.Helpers;
using SysManager.Application.Services;

namespace SysManager.Admin.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
    public class ProductTypeController
    {
        private readonly ProductTypeService _productTypeService;

        public ProductTypeController(ProductTypeService productTypeService) => _productTypeService = productTypeService;

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] ProductTypePostRequest request) => (await _productTypeService.PostAsync(request)).Convert();

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ProductTypePutRequest request) => (await _productTypeService.PutAsync(request)).Convert();

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] ProductTypeGetByFilterRequest request) => (await _productTypeService.GetByFilterAsync(request)).Convert();

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id) => (await _productTypeService.GetByIdAsync(id)).Convert();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) => (await _productTypeService.DeleteByIdAsync(id)).Convert();
    }
}