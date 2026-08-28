using FluentValidation;

namespace ShopService.Controllers.Product.DTOs.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("عنوان محصول الزامی است")
            .MaximumLength(1000)
            .WithMessage("عنوان محصول نباید بیشتر از 100 کاراکتر باشد");

            RuleFor(x => x.Price)
            .GreaterThan(1000)
            .WithMessage("قیمت محصول الگوی استانداردی ندارد");
        }
    }
}
