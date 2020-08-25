﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestCarShop___Admin.Class_files.Views;

namespace TheBestCarShop___Admin.Class_files.Validators
{
    public class NewAdminValidator : AbstractValidator<NewAdminView>
    {
        public NewAdminValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            
            //User
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name must not be empty")
                .MinimumLength(3)
                .WithMessage("First name must be at least 3 characters long in order to generate your username properly.");

            RuleFor(x => x.SecondName)
                .NotEmpty()
                .WithMessage("Second name must not be empty")
                .MinimumLength(3)
                .WithMessage("Second name must be at least 3 characters long in order to generate your username properly.");

            RuleFor(x => x.CompanyName);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email must not be empty.")
                .EmailAddress()
                .WithMessage("Email's format must be: username@domain");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number must not be empty.")
                .Matches("/d/d/d/d/d/d/d/d/d")
                .WithMessage("Phone number must only consist of digits.");


            //Address
            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("Country name must not be empty.");
            
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City name must not be empty.");

            RuleFor(x => x.Street)
                .NotEmpty()
                .WithMessage("Street name must not be empty.");

            RuleFor(x => x.Postcode)
                .NotEmpty()
                .WithMessage("Postcode must not be empty.")
                .MinimumLength(5)
                .WithMessage("Postcode must be at least 5 characters long.");

            RuleFor(x => x.BuildingNumber)
                .NotEmpty()
                .WithMessage("Building number must not be empty.")
                .Matches("/d*")
                .WithMessage("Building number must consist of at least one digit.");


            //Account
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username must not be empty, please generate it using a button.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long."); //must contain at least 1 number, etc.?                 
        }
    }
}