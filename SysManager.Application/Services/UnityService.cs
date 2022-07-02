using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Helpers;
using SysManager.Application.Validators.User.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Services
{
    public class UnityService
    {
        //private readonly UserRepository _userRepository;
        public UnityService()
        {
        }

        public async Task<ResultData> PostAsync(UnityPostRequest request)
        {
            try
            {
                
                
                return Utils.SuccessData("");
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public async Task<ResultData> PutAsync(UnityPutRequest request)
        {
            try
            {
                
                
                return Utils.SuccessData("");
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            try
            {
                
                
                return Utils.SuccessData("");
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public async Task<ResultData> GetByFilterAsync(UnityGetByFilterRequest request)
        {
            try
            {
                
                
                return Utils.SuccessData("");
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public async Task<ResultData> DeleteByIdAsync(Guid id)
        {
            try
            {
                
                
                return Utils.SuccessData("");
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}