using FluentValidation;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Erros;
using SysManager.Application.Helpers;

namespace SysManager.Application.Validators.User.Request
{
    public class UserPostRequestValidator: AbstractValidator<UserPostRequest>
    {
        public UserPostRequestValidator(UserRepository repository)
        {
            RuleFor(x => x.UserName)
                .Must(username => !string.IsNullOrEmpty(username))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(x => x.Email)
                .Must(email => !string.IsNullOrEmpty(email))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(x => x.Password)
                .Must(password => !string.IsNullOrEmpty(password))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_Password_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(user => user)
                .Must(user => {
                    var result = repository.GetUserByUserNameOrEmailAsync(user.UserName, user.Email).Result;
                    return result == null;
                })
                .WithMessage(SysManagerErrors.User_Post_BadRequest_Email_Or_UserName_Cannot_Be_Duplicated.Description());
        }
    }
}