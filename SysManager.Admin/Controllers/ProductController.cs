using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.Product.Request;
using SysManager.Application.Helpers;
using SysManager.Application.Services;

namespace SysManager.Admin.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService) => _productService = productService;

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] ProductPostRequest request) => (await _productService.PostAsync(request)).Convert();

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ProductPutRequest request) => (await _productService.PutAsync(request)).Convert();

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] ProductGetByFilterRequest request) => (await _productService.GetByFilterAsync(request)).Convert();

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id) => (await _productService.GetByIdAsync(id)).Convert();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) => (await _productService.DeleteByIdAsync(id)).Convert();
    }
}