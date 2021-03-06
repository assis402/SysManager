using SysManager.Application.Contracts.Product.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;
using SysManager.Application.Validators.Product;
using System;
using System.Threading.Tasks;

namespace SysManager.Application.Services
{
    public class ProductService
    {
		private readonly ProductRepository _productRepository;
        private readonly ProductTypeRepository _productTypeRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly UnityRepository _unityRepository;

        public ProductService(ProductRepository productRepository, 
                              ProductTypeRepository productTypeRepository,
                              CategoryRepository categoryRepository, 
                              UnityRepository unityRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _categoryRepository = categoryRepository;
            _unityRepository = unityRepository;
        }

        public async Task<ResultData> PostAsync(ProductPostRequest product)
        {
            var validator = new ProductPostRequestValidator(_productRepository, _productTypeRepository, _categoryRepository, _unityRepository);
            var validationResult = validator.Validate(product);

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorCodeList());

            var entity = new ProductEntity(product);
            return Utils.SuccessData(await _productRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(ProductPutRequest product)
        {
            var validator = new ProductPutRequestValidator(_productRepository, _productTypeRepository, _categoryRepository, _unityRepository);
            var validationResult = validator.Validate(product);

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorCodeList());

            var entity = new ProductEntity(product);
            return Utils.SuccessData(await _productRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> GetByFilterAsync(ProductGetByFilterRequest product)
        {
            var response = await _productRepository.GetByFilterAsync(product);
            return Utils.SuccessData(response);
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            var response = await _productRepository.GetByIdAsync(id);
            if (response == null)
                return Utils.ErrorData(SysManagerErrors.Product_Put_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());

            return Utils.SuccessData(response);
        }

        public async Task<ResultData> DeleteByIdAsync(Guid id)
        {
            var exists = await _productRepository.GetByIdAsync(id);
            if (exists == null)
                return Utils.ErrorData(SysManagerErrors.Product_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());

            var response = await _productRepository.DeleteByIdAsync(id);
            return Utils.SuccessData(response);
        }
    }
}