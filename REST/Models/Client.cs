using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    ///<summary>
    ///This class handles information and functionality for a Company
    ///</summary>
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string CompanyName { get; set; }
        public List<Need> Needs{ get; set; }
        public List<ClientUser> ClientUsers { get; set; }

        public Client()
        {
        }
    }

    public class CompanyValidator : AbstractValidator<Client>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.CompanyName)
              .NotNull()
              .Length(2, 50)
              .WithMessage("Must be inbetween 2 and 50 characters");
        }
    }
}