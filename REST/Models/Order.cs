using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{

    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
        public Order()
        {
        }

    }
    public class OrdersValidator : AbstractValidator<Order>
    {
        public OrdersValidator()
        {
            RuleFor(o => o.Id)
                .NotNull()
                .WithMessage("Must include an order ID.");
            RuleFor(o => o.ClientId)
                .NotNull()
                .WithMessage("Must include client ID.");
        }
    }
}