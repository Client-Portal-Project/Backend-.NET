using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace REST.DataLayer
{
   public interface IApplicantSkillRepo
    {
        /// <summary>
        /// add new applicant skill in the Database
        /// </summary>
        /// <param name="applicantSkill"></param>
        /// <returns>ApplicantSkill object</returns>
        public Task<ApplicantSkill> AddApplicantSkill(ApplicantSkill applicantSkill);

        /// <summary>
        /// get applicant skills in the database by applicant ID
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns>List of applicant skills</returns>
        public Task<List<ApplicantSkill>> GetApplicantSkillsByApplicantId(int applicantId);

        /// <summary>
        /// get applicant skills in the database by Skill ID
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns>List of applicant skills</returns>
        public Task<List<ApplicantSkill>> GetApplicantSkillsBySkillId(int skillId);

        /// <summary>
        /// remove an applicant skill from the data base by applicant skill id
        /// </summary>
        /// <param name="applicantSkillId"></param>
        /// <returns>Applicant object</returns>
        public Task<ApplicantSkill> DeleteApplicantSkillById(int applicantSkillId);
    }
}
