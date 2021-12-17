using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    ///<summary>
    ///This class handles information about Topics for Occupations
    ///</summary>
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public string TopicName { get; set; }
        public Topic()
        {
        }
    }
    
    public class TopicsValidator :AbstractValidator<Topic>
    {
        public TopicsValidator()
        {
            RuleFor(t => t.Id)
                .NotNull()
                .WithMessage("Must include topic ID.");
            RuleFor(t => t.TopicName)
                .NotNull()
                .WithMessage("Must include Topic Name.");
            RuleFor(t => t.TopicName)
                .Length(2,50)
                .WithMessage("Must be inbetween 2 and 50 characters");
        }
    }
}