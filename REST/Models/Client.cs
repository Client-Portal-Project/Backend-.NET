using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    ///<summary>
    ///This class handles information and functionality for a Client
    ///</summary>
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Client()
        {
        }
    }

    public class ClientsValidator : AbstractValidator<Client>
    {
        public ClientsValidator()
        {
            RuleFor(c => c.Name)
              .NotNull()
              .Length(2, 50)
              .WithMessage("Must be inbetween 2 and 50 characters");
            RuleFor(c => c.Email)
              .EmailAddress()
              .WithMessage("Not a valid email address");
            RuleFor(c => c.Street)
              .Length(2, 50)
              .WithMessage("Must be inbetween 2 and 50 characters");
            RuleFor(c => c.City)
              .Length(2, 50)
              .WithMessage("Must be inbetween 2 and 50 characters");
            RuleFor(c => c.StateProvince)
              .Length(2, 50)
              .WithMessage("Must be inbetween 2 and 50 characters");
            RuleFor(c => c.Country)
              .NotNull()
              .Length(2, 50)
              .WithMessage("Must be inbetween 2 and 50 characters");

            RuleFor(c => c.Phone)
              .Must(IsValidPhoneNumber)
              .WithMessage("Not a valid phone number");
        }

        private bool IsValidPhoneNumber(string Phone)
        {
            return Regex.Match(Phone, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").Success;
        }
    }
}