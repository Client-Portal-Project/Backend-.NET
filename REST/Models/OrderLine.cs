using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    ///<summary>
    ///This class handles the information of an order
    ///</summary>.
    public class OrderLine
    {
        [Key]
        public int Id { get; set; }
        public int OccupationId { get; set; }

        ///<summary>
        ///Id used for the Order Entity
        ///</summary>
        public int OrderId { get; set; }
        public int AssociateCount { get; set; }
        public DateTime DateNeeded { get; set; }
        public OrderLine()
        {
        }
    }

    public class OrderDetailsValidator : AbstractValidator<OrderLine>
    {
        public OrderDetailsValidator()
        {
            RuleFor(o => o.OccupationId)
                .NotNull()
                .WithMessage("Must include a Occupation ID.");
            RuleFor(o => o.OrderId)
                .NotNull()
                .WithMessage("Must include an order ID.");
            RuleFor(o => o.AssociateCount)
                .GreaterThan(0)
                .WithMessage("Associate count must be more than 0.");
            RuleFor(o => o.AssociateCount)
                .NotNull()
                .WithMessage("Must include an associate count.");
            RuleFor(o => o.DateNeeded)
                .GreaterThan(DateTime.Now)
                .WithMessage("Date needed must be later than current date.");
        }
    }
}
