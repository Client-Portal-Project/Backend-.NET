using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace REST.DataLayer
{
    public interface ISkillRepo
    {
        /// <summary>
        /// Get all of the skills in the Db
        /// </summary>
        /// <returns>List Of Skills</returns>
        Task<List<Skill>> GetAllSkills();

        /// <summary>
        /// Get all of the skills an Applicant 
        /// </summary>
        /// <param name="ApplicantId"></param>
        /// <returns>List Of Skills</returns>
        Task<List<Skill>> GetSkillsById(int ApplicantId);

        /// <summary>
        /// Adds a new skill to the DB
        /// </summary>
        /// <param name="Skill"></param>
        /// <returns>SKill obj</returns>
        Task<Skill> AddSkill(Skill Skill);

       /// <summary>
       /// Updates the information if an existing Skill
       /// </summary>
       /// <param name="Skill"></param>
       /// <returns>Skil obj</returns>
        Task<Skill> UpdateSkills(Skill Skill);

        /// <summary>
        /// Deletes an existing Skill from the DB 
        /// </summary>
        /// <param name="SkillId"></param>
        /// <returns>Skill obj</returns>
        Task<Skill> DeleteSkillById(int SkillId);
    }
}
