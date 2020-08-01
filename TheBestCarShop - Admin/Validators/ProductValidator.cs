using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TheBestCarShop___Admin.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.CarFirstProdYear)
                .NotEmpty()
                .InclusiveBetween(1900, 2050)
                .WithMessage("test");
        }
    }
}
