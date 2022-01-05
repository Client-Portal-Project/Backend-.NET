using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using FluentValidation;

namespace REST.Models
{
    ///<summary>
    ///This class handles which users are assigned to which client
    ///</summary>
    public class ClientUser
    {
        [Key]
        public int ClientUserId { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public User User{ get; set; }

        public ClientUser()
        {
        }
    }

    public class ClientUserValidator : AbstractValidator<ClientUser>
    {
    }
}