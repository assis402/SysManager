using Moq;
using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Data.MySql;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;
using SysManager.Application.Services;
using SysManager.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SysManager.Test.Services
{
    public class UnityServiceTests
    {
        private UnityService _service;
        private readonly Mock<UnityRepository> _mockRepository;

        public UnityServiceTests()
        {
            _mockRepository = new Mock<UnityRepository>(new MySqlContext()) { CallBase = false };
        }

        [Theory(DisplayName = "Unity - Criação com sucesso")]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Unity_Creation_Success(bool active)
        {
            //Arrange
            var request = new UnityPostRequest()
            {
                Active = active,
                Name = "test"
            };

            var response = new ResponseDefault("Unidade de Medida criada com sucesso", false, Guid.NewGuid().ToString());

            _mockRepository.MockGetByNameAsync(null)
                           .MockCreateAsync(response);

            _service = new UnityService(_mockRepository.Object);

            //Act
            var result = await _service.PostAsync(request);

            //Assert
            Assert.True(result.Success);

            var jsonResponse = response.ToJson();
            var jsonResultData = result.Data.ToJson();

            Assert.Equal(jsonResponse, jsonResultData);
        }

        [Fact(DisplayName = "Unity - Criação com erro")]
        public async Task Unity_Creation_Error()
        {
            //Arrange
            var request = new UnityPostRequest()
            {
                Active = true,
                Name = null
            };

            var response = new List<string>()
            {
                "É necessário informar o nome da unidade de medida"
            };

            _mockRepository.MockGetByNameAsync(null);

            _service = new UnityService(_mockRepository.Object);

            //Act
            var result = await _service.PostAsync(request);

            //Assert
            Assert.False(result.Success);

            var jsonResponse = response.ToJson();
            var jsonResultData = result.Data.ToJson();

            Assert.Equal(jsonResponse, jsonResultData);
        }

        [Fact(DisplayName = "Unity - Atualização com sucesso")]
        public async Task Unity_Update_Success()
        {
            //Arrange
            var id = Guid.NewGuid();

            var request = new UnityPutRequest()
            {
                Id = id,
                Name = "test",
                Active = false
            };

            var unityEntity = new UnityEntity(request);
            var response = new ResponseDefault("Unidade de Medida alterada com sucesso", false, id.ToString());

            _mockRepository.MockGetByNameAsync(unityEntity)
                           .MockUpdateAsync(response);

            _service = new UnityService(_mockRepository.Object);

            //Act
            var result = await _service.PutAsync(request);

            //Assert
            Assert.True(result.Success);

            var jsonResponse = response.ToJson();
            var jsonResultData = result.Data.ToJson();

            Assert.Equal(jsonResponse, jsonResultData);
        }

        [Fact(DisplayName = "Unity - Atualização com erro")]
        public async Task Unity_Update_Error()
        {
            //Arrange
            var id = Guid.NewGuid();

            var request = new UnityPutRequest()
            {
                Id = id,
                Name = "test",
                Active = false
            };

            var unityEntity = new UnityEntity()
            {
                Id = Guid.NewGuid(),
                Name = "test",
                Active = false
            };

            var response = new List<string>()
            {
                SysManagerErrors.Unity_Put_BadRequest_Name_Cannot_Be_Duplicated.Description()
            };

            _mockRepository.MockGetByNameAsync(unityEntity);
            _service = new UnityService(_mockRepository.Object);

            //Act
            var result = await _service.PutAsync(request);

            //Assert
            Assert.False(result.Success);

            var jsonResponse = response.ToJson();
            var jsonResultData = result.Data.ToJson();

            Assert.Equal(jsonResponse, jsonResultData);
        }

        [Fact(DisplayName = "Unity - Busca com sucesso")]
        public async Task Unity_GetById_Success()
        {
            //Arrange
            var id = Guid.NewGuid();
            var unityEntity = new UnityEntity()
            {
                Id = id,
                Name = "test",
                Active = true
            };

            _mockRepository.MockGetByIdAsync(unityEntity);
            _service = new UnityService(_mockRepository.Object);

            //Act
            var result = await _service.GetByIdAsync(id);

            //Assert
            Assert.True(result.Success);

            var jsonResponse = unityEntity.ToJson();
            var jsonResultData = result.Data.ToJson();

            Assert.Equal(jsonResponse, jsonResultData);
        }

        [Fact(DisplayName = "Unity - Busca com erro")]
        public async Task Unity_GetById_Error()
        {
            //Arrange
            var id = Guid.NewGuid();

            var response = SysManagerErrors.Unity_Put_BadRequest_Id_Is_Invalid_Or_Inexistent.Description();

            _mockRepository.MockGetByIdAsync(null);
            _service = new UnityService(_mockRepository.Object);

            //Act
            var result = await _service.GetByIdAsync(id);

            //Assert
            Assert.False(result.Success);
            Assert.Equal(response, result.Data);
        }

        [Fact(DisplayName = "Unity - Deleção com sucesso")]
        public async Task Unity_DeleteById_Success()
        {
            //Arrange
            var id = Guid.NewGuid();
            var unityEntity = new UnityEntity()
            {
                Id = id,
                Name = "test",
                Active = true
            };

            var response = new ResponseDefault("Unidade de Medida excluída com sucesso", false, id.ToString());

            _mockRepository.MockGetByIdAsync(unityEntity)
                           .MockDeleteByIdAsync(response);

            _service = new UnityService(_mockRepository.Object);

            //Act
            var result = await _service.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.Success);

            var jsonResponse = response.ToJson();
            var jsonResultData = result.Data.ToJson();

            Assert.Equal(jsonResponse, jsonResultData);
        }

        [Fact(DisplayName = "Unity - Deleção com erro")]
        public async Task Unity_DeleteById_Error()
        {
            //Arrange
            var id = Guid.NewGuid();
            var response = SysManagerErrors.Unity_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent.Description();

            _mockRepository.MockGetByIdAsync(null);
            _service = new UnityService(_mockRepository.Object);

            //Act
            var result = await _service.DeleteByIdAsync(id);

            //Assert
            Assert.False(result.Success);
            Assert.Equal(response, result.Data);
        }

        [Fact(DisplayName = "Unity - Busca por filtro com sucesso")]
        public async Task Unity_GetByFilter_Success()
        {
            //Arrange
            var request = new UnityGetByFilterRequest()
            {
                Name = "test",
                Active = "todos",
                page = 1,
                pageSize = 10
            };

            var response = new PaginationResponse<UnityEntity>()
            {
                _pageSize = 10,
                _page = 1,
                _total = 20,
                Items = new List<UnityEntity>() { new UnityEntity() }
            };

            _mockRepository.MockGetByFilterAsync(response);
            _service = new UnityService(_mockRepository.Object);

            //Act
            var result = await _service.GetByFilterAsync(request);

            //Assert
            Assert.True(result.Success);

            var jsonResponse = response.ToJson();
            var jsonResultData = result.Data.ToJson();

            Assert.Equal(jsonResponse, jsonResultData);
        }
    }
}