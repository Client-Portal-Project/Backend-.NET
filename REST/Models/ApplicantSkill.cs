using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    ///<summary>
    ///Join table to show which skills each applicant claims to have
    ///</summary>
    public class ApplicantSkill
    {
        [Key]
        public int ApplicantSkillId { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        public ApplicantSkill()
        {
        }
    }

    public class ApplicantSkillValidator : AbstractValidator<ApplicantSkill>
    {
    }
}