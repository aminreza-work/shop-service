using FluentValidation;


namespace ShopService.Controllers.Shop.DTOs.Validators
{
    public class CreateShopValidator : AbstractValidator<CreateShopDTO>
    {
        public CreateShopValidator()
        {
            RuleFor(x => x.ShopTitle)
            .NotEmpty()
            .WithMessage("عنوان مغازه الزامی است")
            .MaximumLength(120)
            .WithMessage("عنوان مغازه نباید بیشتر از 120 کاراکتر باشد");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("شماره موبایل الزامی است!")
                .Matches(@"^09\d{9}$")
                .WithMessage("شماره موبایل معتبر نیست");
        }
    }
}
