using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    ///<summary>
    ///Join table to show which skills a need requires
    ///</summary>
    public class SkillNeed
    {
        [Key]
        public int SkillNeedId { get; set; }
        [ForeignKey("Need")]
        public int NeedId { get; set; }
        public Need Need { get; set; }
        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        public SkillNeed()
        {
        }
    }

    public class SkillNeedValidator : AbstractValidator<SkillNeed>
    {
    }
}