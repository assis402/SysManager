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
            RuleFor(contract => contract.Id)
                .Must(id => !string.IsNullOrEmpty(id.ToString()))
                .WithMessage(SysManagerErrors.Unity_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());

            RuleFor(contract => contract.Name)
                .Must(name => !string.IsNullOrEmpty(name))
                .WithMessage(SysManagerErrors.Unity_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract)
                .Must(x =>
                {
                    var exists = repository.GetByNameAsync(x.Name).Result;

                    if (exists != null)
                        if (exists.Id != x.Id)
                            return false;

                    return true;
                })
                .WithMessage(SysManagerErrors.Unity_Put_BadRequest_Name_Cannot_Be_Duplicated.Description());
        }
    }
}