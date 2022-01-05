using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace REST.DataLayer.Interfaces
{
    public interface IApplicantSkillRepo : IGenericRepo<ApplicantSkill>
    {
        // methods specific to Client table
    }
}
