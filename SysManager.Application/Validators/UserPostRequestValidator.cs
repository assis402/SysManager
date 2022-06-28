using FluentValidation;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Erros;

namespace SysManager.Application.Validators
{
    public class UserPostRequestValidator: AbstractValidator<UserPostRequest>
    {
        public UserPostRequestValidator()
        {
            RuleFor(x => x.UserName)
                .Must(username => !string.IsNullOrEmpty(username))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty.ToString());

            RuleFor(x => x.Email)
                .Must(email => !string.IsNullOrEmpty(email))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty.ToString());

            RuleFor(x => x.Password)
                .Must(password => !string.IsNullOrEmpty(password))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_Password_Cannot_Be_Null_Or_Empty.ToString());
        }
    }
}