using SysManager.Application.Contracts.Category.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;
using SysManager.Application.Validators.Category;
using System;
using System.Threading.Tasks;

namespace SysManager.Application.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository repository) => this._categoryRepository = repository;

        public async Task<ResultData> PostAsync(CategoryPostRequest category)
        {
            var validator = new CategoryPostRequestValidator(_categoryRepository);
            var validationResult = validator.Validate(category);

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorCodeList());

            var entity = new CategoryEntity(category);
            return Utils.SuccessData(await _categoryRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(CategoryPutRequest category)
        {
            var validator = new CategoryPutRequestValidator(_categoryRepository);
            var validationResult = validator.Validate(category);

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorCodeList());

            var entity = new CategoryEntity(category);
            return Utils.SuccessData(await _categoryRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> GetByFilterAsync(CategoryGetByFilterRequest category)
        {
            var response = await _categoryRepository.GetByFilterAsync(category);
            return Utils.SuccessData(response);
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            var response = await _categoryRepository.GetByIdAsync(id);
            if (response == null)
                return Utils.ErrorData(SysManagerErrors.Category_Put_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());

            return Utils.SuccessData(response);
        }

        public async Task<ResultData> DeleteByIdAsync(Guid id)
        {
            var exists = await _categoryRepository.GetByIdAsync(id);
            if (exists == null)
                return Utils.ErrorData(SysManagerErrors.Category_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());

            var response = await _categoryRepository.DeleteByIdAsync(id);
            return Utils.SuccessData(response);
        }
    }
}