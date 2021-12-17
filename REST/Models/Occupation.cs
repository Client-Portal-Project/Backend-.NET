using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    public class Occupation
    {
        [Key]
        public int Id { get; set; }
        public string OccupationName { get; set; }
        public string Description { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
        public Occupation()
        {
        }
    }

    public class OccupationsValidator : AbstractValidator<Occupation>
    {
        public OccupationsValidator()
        {
            RuleFor(c => c.OccupationName)
                .Length(2, 50)
                .WithMessage("Must be in between 2 and 50 characters");
            RuleFor(c => c.Description)
                .Length(2, 50)
                .WithMessage("Must be in between 2 and 50 characters");
        }
    }
}
