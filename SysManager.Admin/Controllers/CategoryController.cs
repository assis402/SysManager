using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.Category.Request;
using SysManager.Application.Helpers;
using SysManager.Application.Services;

namespace SysManager.Admin.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController
    {
        private readonly CategoryService _categoryService;
        
        public CategoryController(CategoryService categoryService) => _categoryService = categoryService;

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CategoryPostRequest request) => (await _categoryService.PostAsync(request)).Convert();

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] CategoryPutRequest request) => (await _categoryService.PutAsync(request)).Convert();

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] CategoryGetByFilterRequest request) => (await _categoryService.GetByFilterAsync(request)).Convert();

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id) => (await _categoryService.GetByIdAsync(id)).Convert();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) => (await _categoryService.DeleteByIdAsync(id)).Convert();
    }
}