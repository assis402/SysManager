using FluentValidation;
using SysManager.Application.Contracts.Product.Request;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;

namespace SysManager.Application.Validators.Product
{
    public class ProductPostRequestValidator : AbstractValidator<ProductPostRequest>
    {
        public ProductPostRequestValidator(ProductRepository repository)
        {
            RuleFor(contract => contract.Name)
                .Must(name => !string.IsNullOrEmpty(name))
                .WithMessage(SysManagerErrors.Product_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Active)
                .Must(active => active == true || active == false)
                .WithMessage(SysManagerErrors.Product_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Name)
                .Must(name =>
                {
                    var exists = repository.GetByNameAsync(name).Result;
                    return exists == null;
                })
                .WithMessage(SysManagerErrors.Product_Post_BadRequest_Name_Cannot_Be_Duplicated.Description());
        }
    }
}
