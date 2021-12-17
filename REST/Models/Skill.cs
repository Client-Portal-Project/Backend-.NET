using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    ///<summary>
    ///This class handles the list of skills that applicants can have and clients can search for
    ///</summary>
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public List<ApplicantSkill> ApplicantSkills { get; set; }
        public List<SkillNeed> SkillNeeds { get; set; }

        public Skill()
        {
        }
    }

    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(s => s.SkillName)
              .NotNull()
              .Length(6, 50)
              .WithMessage("Must be inbetween 1 and 50 characters");
        }
    }
}