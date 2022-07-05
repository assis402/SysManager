using FluentValidation;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;

namespace SysManager.Application.Validators.Unity
{
    public class UnityPutRequestValidator : AbstractValidator<UnityPutRequest>
    {
        public UnityPutRequestValidator(UnityRepository repository)
        {
            RuleFor(contract => contract.Name)
                .Must(name => !string.IsNullOrEmpty(name))
                .WithMessage(SysManagerErrors.Unity_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Active)
                .Must(active => active == true || active == false)
                .WithMessage(SysManagerErrors.Unity_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract)
                .Must(x =>
                {
                    var exists = repository.GetUnityByNameAsync(x.Name).Result;

                    if (exists != null)
                        if (exists.Id != x.Id)
                            return false;

                    return true;
                })
                .WithMessage(SysManagerErrors.Unity_Post_BadRequest_Name_Cannot_Be_Duplicated.Description());
        }
    }
}
