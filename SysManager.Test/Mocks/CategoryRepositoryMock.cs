using Moq;
using SysManager.Application.Contracts;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Services;

namespace SysManager.Services.Test
{
    public static class CategoryRepositoryMock
    {
        public static void MockCreateAsync(this Mock<CategoryRepository> mockRepository, ResponseDefault response)
        {
            mockRepository.Setup(x => x.CreateAsync(It.IsAny<CategoryEntity>())).ReturnsAsync(response);
        }
    }
}
