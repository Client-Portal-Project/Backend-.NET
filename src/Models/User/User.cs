﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

namespace Models
{
    ///<summary>
    ///This class handles information and functionality for the general User (Owners, Applicants, and Clients)
    ///</summary>
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public boolean email_verified { get; set; }
        public string phone_number { get; set; }
        public boolean phone_number_verified { get; set; }
        public string date_of_birth { get; set; }
        public Owner ?Owner { get; set; }
        public Applicant ?Applicant { get; set; }
        public ClientUser ?ClientUser { get; set; }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Password)
              .NotNull()
              .Length(6, 50)
              .WithMessage("Must be inbetween 6 and 50 characters");

            RuleFor(u => u.Email)
              .EmailAddress()
              .WithMessage("Not a valid email address");

            RuleFor(u => u.FirstName)
              .NotNull()
              .Length(2, 50)
              .WithMessage("Must be inbetween 2 and 50 characters");

            RuleFor(u => u.LastName)
              .NotNull()
              .Length(2, 50)
              .WithMessage("Must be inbetween 2 and 50 characters");
        }
    }
}