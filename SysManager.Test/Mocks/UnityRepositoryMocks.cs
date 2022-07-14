using Moq;
using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using System;

namespace SysManager.Test.Mocks
{
    public static class UnityRepositoryMocks
    {
        public static Mock<UnityRepository> MockGetByNameAsync(this Mock<UnityRepository> mockRepository, UnityEntity response)
        {
            mockRepository.Setup(x => x.GetByNameAsync(It.IsAny<string>())).ReturnsAsync(response);
            return mockRepository;
        }

        public static Mock<UnityRepository> MockCreateAsync(this Mock<UnityRepository> mockRepository, ResponseDefault response)
        {
            mockRepository.Setup(x => x.CreateAsync(It.IsAny<UnityEntity>())).ReturnsAsync(response);
            return mockRepository;
        }

        public static Mock<UnityRepository> MockUpdateAsync(this Mock<UnityRepository> mockRepository, ResponseDefault response)
        {
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<UnityEntity>())).ReturnsAsync(response);
            return mockRepository;
        }

        public static Mock<UnityRepository> MockGetByIdAsync(this Mock<UnityRepository> mockRepository, UnityEntity response)
        {
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(response);
            return mockRepository;
        }

        public static Mock<UnityRepository> MockDeleteByIdAsync(this Mock<UnityRepository> mockRepository, ResponseDefault response)
        {
            mockRepository.Setup(x => x.DeleteByIdAsync(It.IsAny<Guid>())).ReturnsAsync(response);
            return mockRepository;
        }

        public static Mock<UnityRepository> MockGetByFilterAsync(this Mock<UnityRepository> mockRepository, PaginationResponse<UnityEntity> response)
        {
            mockRepository.Setup(x => x.GetByFilterAsync(It.IsAny<UnityGetByFilterRequest>())).ReturnsAsync(response);
            return mockRepository;
        }
    }
}