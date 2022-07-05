using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Helpers;
using SysManager.Application.Validators.User.Request;
using System;
using System.Threading.Tasks;

namespace SysManager.Application.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository) => _userRepository = userRepository;

        public async Task<ResultData> PostLoginAsync(UserPostLoginRequest request)
        {
            try
            {
                var openData = request.Email + ":" + request.Password + ":" + Utils.GetDateExpired(10);
                var dataBytes = Utils.ToBase64Encode(openData);
                var user = await _userRepository.GetUserByCredentialsAsync(request.Email, request.Password);

                if (user != null)
                {
                    var response = new AccountResponse
                    {
                        Id = user.Id.ToString(),
                        Message = "Token successful",
                        Token = dataBytes
                    };
                    
                    return Utils.SuccessData(response);
                }
                
                return Utils.ErrorData(new AccountResponse { Message = "Token Fail" });
            }
            catch (Exception ex)
            {
                return Utils.ErrorData(new { ex.Message });
            }
        }

        public async Task<UserEntity> Authenticate(string email, string password) => await _userRepository.GetUserByCredentialsAsync(email, password);

        public async Task<ResultData> PostAsync(UserPostRequest request)
        {
            try
            {
                var validator = new UserPostRequestValidator(_userRepository);
                var validationResult = validator.Validate(request);

                if(!validationResult.IsValid)
                    return Utils.ErrorData(validationResult.Errors.ToErrorCodeList());
                
                var entity = new UserEntity(request);

                return Utils.SuccessData(await _userRepository.CreateAsync(entity));
            }
            catch (Exception ex)
            {
                return Utils.ErrorData(new { ex.Message });
            }
        }

        public async Task<ResultData> PutAsync(UserPutRequest request)
        {
            try
            {
                var validator = new UserPutRequestValidator(_userRepository);
                var validationResult = validator.Validate(request);

                if(!validationResult.IsValid)
                    return Utils.ErrorData(validationResult.Errors.ToErrorCodeList());

                var user = await _userRepository.GetUserByUserNameAndEmailAsync(request.UserName, request.Email);

                return Utils.SuccessData(await _userRepository.RecoveryAsync(user.Id, request.NewPassword));
            }
            catch (Exception ex)
            {
                return Utils.ErrorData(new { ex.Message });
            }
        }
    }
}