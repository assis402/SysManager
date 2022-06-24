using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<ResultData> PostAsync(UserPostRequest request)
        {
            try
            {
                var errors = new List<string>();

                if (request.Email == "" || request.Email == null)
                    errors.Add("Precisa informar a propriedade (Email)");
                if (request.UserName == "" || request.UserName == null)
                    errors.Add("Precisa informar a propriedade (UserName)");
                if (request.Password == "" || request.Password == null)
                    errors.Add("Precisa informar a propriedade (Password)");
                
                if (errors.Count > 0)
                    return Utils.ErrorData(errors);

                var entity = new UserEntity(request);

                return Utils.SuccessData(await _userRepository.CreateAsync(entity));
            }
            catch (Exception ex)
            {
                return Utils.ErrorData(false);
            }
        }
    }
}