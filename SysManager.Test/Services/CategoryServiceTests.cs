using System;
using System.Threading.Tasks;
using Moq;
using SysManager.Application.Contracts.Category.Request;
using SysManager.Application.Data.MySql;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Services;
using Xunit;

namespace SysManager.Services.Test
{
    public class CategoryServiceTests
    {
        private CategoryService _service;
        private readonly Mock<CategoryRepository> _mockRepository;

        public CategoryServiceTests()
        {
            _mockRepository = new Mock<CategoryRepository>() { CallBase = false };
        }

        [Fact]
        public async Task Category_Creation_SuccessAsync()
        {
            //Arrange
            var request = new CategoryPostRequest() 
                {
                    Name = "Test",
                    Active = false
                };

            _service = new CategoryService(_mockRepository.Object);

            //Act
            var result = await _service.PostAsync(request);
        }
    }
}
