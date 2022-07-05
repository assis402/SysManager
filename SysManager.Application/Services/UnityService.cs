using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;
using SysManager.Application.Validators.Unity;
using SysManager.Application.Validators.User.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Services
{
    public class UnityService
    {
        private readonly UnityRepository _unityRepository;

        public UnityService(UnityRepository repository)
        {
            this._unityRepository = repository;
        }

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
            return Utils.SuccessData(await _unityRepository.CreateAsync(entity));
        }

        public async Task<ResultData> GetByFilterAsync(UnityGetByFilterRequest unity)
        {
            var response = await _unityRepository.GetByFilterAsync(unity);
            return Utils.SuccessData(response);
        }

        public async Task<ResultData> GetAsync(Guid id)
        {
            var response = await _unityRepository.GetByIdAsync(id);
            if (response == null)
                return Utils.ErrorData(SysManagerErrors.Unity_Put_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());

            return Utils.SuccessData(response);
        }

        public async Task<ResultData> DeleteAsync(Guid id)
        {
            var exists = await _unityRepository.GetByIdAsync(id);
            if (exists == null)
                return Utils.ErrorData(SysManagerErrors.Unity_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());

            var response = await _unityRepository.DeleteByIdAsync(id);
            return Utils.SuccessData(response);
        }

    }
}