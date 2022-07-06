using FluentValidation;
using SysManager.Application.Contracts.Product.Request;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;

namespace SysManager.Application.Validators.Product
{
    public class ProductPutRequestValidator : AbstractValidator<ProductPutRequest>
    {
        public ProductPutRequestValidator(ProductRepository repository)
        {
            RuleFor(contract => contract.Name)
                .Must(name => !string.IsNullOrEmpty(name))
                .WithMessage(SysManagerErrors.Product_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Active)
                .Must(active => active == true || active == false)
                .WithMessage(SysManagerErrors.Product_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract)
                .Must(x =>
                {
                    var exists = repository.GetByNameAsync(x.Name).Result;

                    if (exists != null)
                        if (exists.Id != x.Id)
                            return false;

                    return true;
                })
                .WithMessage(SysManagerErrors.Product_Put_BadRequest_Name_Cannot_Be_Duplicated.Description());
        }
    }
}
