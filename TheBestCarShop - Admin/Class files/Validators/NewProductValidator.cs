using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TheBestCarShop___Admin.Viewmodels;

namespace TheBestCarShop___Admin.Validators
{
    public class NewProductValidator : AbstractValidator<NewProductView>
    {
        public NewProductValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.CarBrand)
                .NotEmpty()
                .WithMessage("Car brand must be chosen.")
                .Must(x => x.ToString() != "");

            RuleFor(x => x.CarModel)
                .NotEmpty()
                .WithMessage("Car model must not be empty.")
                .Must(x => x.ToString() != "");
            
            RuleFor(x => x.CarFirstProdYear)
                .NotEmpty()
                .WithMessage("First year must not be empty.")
                .InclusiveBetween(1900, 2050)
                .WithMessage("First year must be a value between 1900 and 2050.");

            RuleFor(x => x.CarLastProdYear)
                .NotEmpty()
                .WithMessage("Last year must not be empty.")
                .InclusiveBetween(1900, 2050)
                .WithMessage("Last year must be an integer between 1900 and 2050.")
                .GreaterThanOrEqualTo(x => x.CarFirstProdYear)
                .WithMessage("Last year must be greater or equal to first year of production.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("A part needs a name.");

            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage("Category must not be empty.");

            RuleFor(x => x.Manufacturer)
                .NotEmpty()
                .WithMessage("Manufacturer must not be empty.");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Product must have a price.")
                .GreaterThan(0)
                .WithMessage("Price must not be negative.");



            //something's not right

            //RuleFor(x => x.IsAvailable)
            //    .NotEmpty()
            //    .WithMessage("Availability must be chosen.");

            
            //RuleFor(x => x.Quantity)
            //    .GreaterThanOrEqualTo(0)
            //    .When(y => y.IsAvailable = true)
            //    .WithMessage("Quantity must be an integer greater than 0.");
        }
    }
}
