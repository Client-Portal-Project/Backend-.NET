using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using FluentValidation;

namespace Models
{
    ///<summary>
    ///This class handles information and functionality for scheduling and recording interviews
    ///</summary>
    public class Interview
    {
        [Key]
        public int InterviewId { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Application")]
        public int ApplicationId { get; set; }
        public Application ?Application { get; set; }
    }

    public class InterviewValidator : AbstractValidator<Interview>
    {
        public InterviewValidator()
        {

        }
    }
}