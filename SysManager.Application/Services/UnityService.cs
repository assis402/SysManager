using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;
using SysManager.Application.Validators.Unity;
using System;
using System.Threading.Tasks;

namespace SysManager.Application.Services
{
    public class UnityService
    {
        private readonly UnityRepository _unityRepository;

        public UnityService(UnityRepository repository) => this._unityRepository = repository;

        public async Task<ResultData> PostAsync(UnityPostRequest unity)
        {
            var validator = new UnityPostRequestValidator(_unityRepository);
            var validationResult = validator.Validate(unity);

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorCodeList());

            var entity = new UnityEntity(unity);
            return Utils.SuccessData(await _unityRepository.CreateAsync(entity));
        }

        public async Task<ResultData> PutAsync(UnityPutRequest unity)
        {
            var validator = new UnityPutRequestValidator(_unityRepository);
            var validationResult = validator.Validate(unity);

            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorCodeList());

            var entity = new UnityEntity(unity);
            return Utils.SuccessData(await _unityRepository.UpdateAsync(entity));
        }

        public async Task<ResultData> GetByFilterAsync(UnityGetByFilterRequest request)
        {
            var response = await _unityRepository.GetByFilterAsync(request);
            return Utils.SuccessData(response);
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            var response = await _unityRepository.GetByIdAsync(id);
            if (response == null)
                return Utils.ErrorData(SysManagerErrors.Unity_Put_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());

            return Utils.SuccessData(response);
        }

        public async Task<ResultData> DeleteByIdAsync(Guid id)
        {
            var exists = await _unityRepository.GetByIdAsync(id);
            if (exists == null)
                return Utils.ErrorData(SysManagerErrors.Unity_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());

            var response = await _unityRepository.DeleteByIdAsync(id);
            return Utils.SuccessData(response);
        }
    }
}