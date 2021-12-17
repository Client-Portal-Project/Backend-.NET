using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    ///<summary>
    ///This class handles information and functionality for the application of an applicant to a Client's needs
    ///</summary>
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        [ForeignKey("ApplicantOccupation")]
        public int ApplicantOccupationId { get; set; }
        public ApplicantOccupation ApplicantOccupation { get; set; }

        [ForeignKey("Need")]
        public int NeedId { get; set; }
        public Need Need { get; set; }
        public DateTime DateOfApplication { get; set; }
        public int Status { get; set; }
        public List<Interview> Interviews { get; set; }

        public Application()
        {
        }
    }

    public class ApplicationValidator : AbstractValidator<Application>
    {
        public ApplicationValidator()
        {

        }
    }
}