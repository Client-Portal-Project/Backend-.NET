using FluentValidation;
using REST.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST.Models
{
    /// <summary>
    /// Needs table describs the needs for an application given by a specific Client
    /// </summary>
    public class Need
    {
        [Key]
        public int NeedId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int AmountNeeded { get; set; }
        public int AmountFulfilled { get; set; }
        // EduField: Biology, HVAC, CompSci...ect
        public string EducationField { get; set; }
        public int YearsExperience { get; set; }
        public List<SkillNeed> SkillNeeds { get; set; }
        public List<Application> Applications { get; set; }
        public string ExtraDescription { get; set; }
        public string JobTitle { get; set; }
        // Edu Lvl: Associate, Batchelor, ext...
        public string EducationLevel { get; set; }

        public Need()
        {

        }
    }
}

public class NeedsValidator : AbstractValidator<Need>
{
    public NeedsValidator()
    {
        RuleFor(n => n.AmountNeeded)
          .NotNull()
          // Less than able to be changed to any reasonable number
          .LessThan(50)
          .WithMessage("Must a reasonably sized number")
          .GreaterThan(0)
          .WithMessage("Need must be at least 1");
        RuleFor(n => n.AmountFulfilled)
            .NotNull()
            .GreaterThanOrEqualTo(0);
        RuleFor(n => n.EducationField)
            // Nullable in case someone has more experience and little or no education
            .MaximumLength(30)
            .WithMessage("Must be less than 30 characters");
        RuleFor(n => n.YearsExperience)
            .NotNull()
            .GreaterThanOrEqualTo(1);
        RuleFor(n => n.ExtraDescription)
            .NotNull()
            // Max length placeholder value. Can be changed as needed to be reasonable length
            .Length(2, 1000)
            .WithMessage("Length must be between 2 and 1000 characters");
        RuleFor(n => n.JobTitle)
            .NotNull()
            .Length(2, 30)
            .WithMessage("Length must be between 2 and 1000 characters");
        RuleFor(n => n.EducationLevel)
            // Left nullable if someone doesnt have degree but does have experience
            .MaximumLength(30)
            .WithMessage("Must be 30 characters or less");
            
    }
}