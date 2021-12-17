using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    ///<summary>
    ///This class handles information and functionality for the job role history of an applicant and their willingness to be marketed on that job role
    ///</summary>
    public class ApplicantOccupation
    {
        [Key]
        public int ApplicantOccupationId { get; set; }

        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public List<Application> Applications { get; set; }
        public string JobTitle { get; set; }
        public int YearsExperience { get; set; }
        public bool OpenMarket { get; set; }

        public ApplicantOccupation()
        {
        }
    }

    public class ApplicantOccupationValidator : AbstractValidator<ApplicantOccupation>
    {
        public ApplicantOccupationValidator()
        {
            RuleFor(a => a.JobTitle)
              .NotNull()
              .Length(2, 50)
              .WithMessage("Must be inbetween 2 and 50 characters");
            RuleFor(a => a.YearsExperience)
              .InclusiveBetween(0,80)
              .WithMessage("Must be between 0 and 80");
        }
    }
}