using System;
using System.Collections.Generic;
using System.Data;
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
                .WithMessage("First year must not be empty.")
                .InclusiveBetween(1900, 2050)
                .WithMessage("First year must be a value between 1900 and 2050.");

            RuleFor(x => x.CarLastProdYear)
                .NotEmpty()
                .WithMessage("Last year must not be empty.")
                .InclusiveBetween(1900, 2050)
                .WithMessage("Last year must be a value between 1900 and 2050.")
                .GreaterThanOrEqualTo(x => x.CarFirstProdYear)
                .WithMessage("Last year must be greater or equal to first year of production.");



            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Quantity must not be empty.")
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0.");
                
        }
    }
}
