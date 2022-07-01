using FluentValidation;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Erros;
using SysManager.Application.Helpers;

namespace SysManager.Application.Validators.User.Request
{
    public class UserPutRequestValidator: AbstractValidator<UserPutRequest>
    {
        public UserPutRequestValidator(UserRepository repository)
        {
            RuleFor(x => x.UserName)
                .Must(username => !string.IsNullOrEmpty(username))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(x => x.Email)
                .Must(email => !string.IsNullOrEmpty(email))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(x => x.NewPassword)
                .Must(password => !string.IsNullOrEmpty(password))
                .WithMessage(SysManagerErrors.User_Put_BadRequest_NewPassword_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(x => x)
                .Must(contract => {
                    var result = repository.GetUserByUserNameAndEmailAsync(contract.UserName, contract.Email).Result;
                    return result != null;
                })
                .WithMessage(SysManagerErrors.User_Put_BadRequest_UserName_Or_Email_Is_Invalid.Description());
        }
    }
}