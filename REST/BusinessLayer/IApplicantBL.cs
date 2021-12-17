using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the service applies to our entity model, refactor if needed
namespace REST.BusinessLayer
{
    public interface IApplicantBL
    {
        /// <summary>
        /// add new applicant in the Database
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns>Applicant object</returns>
        Task<Applicant> AddApplicant(Applicant applicant);

        /// <summary>
        /// get all the applicants in the database
        /// </summary>
        /// <returns>List of applicants</returns>
        Task<List<Applicant>> GetApplicants();

        /// <summary>
        /// get an applicant by applicant id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Applicant object</returns>
        Task<Applicant> GetApplicantById(int Id);

        /// <summary>
        /// updates an applicant's info in the database
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns>Applicant object or null if no object found</returns>
        Task<Applicant> UpdateApplicant(Applicant applicant);

        /// <summary>
        /// remove an applicant from the data base by applicant id
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns>Client object</returns>
        Task<Applicant> DeleteApplicantById(int applicantId);

        /// <summary>
        /// add an applicant occupation to the database
        /// </summary>
        /// <param name="applicantOccupation"></param>
        /// <returns>ApplicantOccupation object</returns>
        Task<ApplicantOccupation> AddApplicantOccupation(ApplicantOccupation applicantOccupation);

        /// <summary>
        /// get list of all applicant occupations
        /// </summary>
        /// <returns>list of ApplicantOccupation objects</returns>
        Task<List<ApplicantOccupation>> GetApplicantOccupations();

        /// <summary>
        /// get an applicant occupation by applicant occupation id
        /// </summary>
        /// <param name="applicantOccupationId"></param>
        /// <returns>ApplicantOccupation object</returns>
        Task<ApplicantOccupation> GetApplicantOccupationById(int applicantOccupationId);

        /// <summary>
        /// get a list of applicant occupations by applicant id
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns>list of ApplicantOccupation objects</returns>
        Task<List<ApplicantOccupation>> GetApplicantOccupationByApplicantId(int applicantId);

        /// <summary>
        /// update an applicant occupation in the database
        /// </summary>
        /// <param name="applicantOccupation"></param>
        /// <returns>ApplicantOccupation object</returns>
        Task<ApplicantOccupation> UpdateApplicantOccupation(ApplicantOccupation applicantOccupation);

        /// <summary>
        /// remove an applicant occupation from the data base by applicant occupation id
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns>Client object</returns>
        Task<ApplicantOccupation> DeleteApplicantOccupation(int applicantOccupationId);

        /// <summary>
        /// add an applicant skill to the database
        /// </summary>
        /// <param name="applicantSkill"></param>
        /// <returns>ApplicantSkill object</returns>
        Task<ApplicantSkill> AddApplicantSkill(ApplicantSkill applicantSkill);

        /// <summary>
        /// get a list of applicant skills by applicant id
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns>list of ApplicantSkill objects</returns>
        Task<List<ApplicantSkill>> GetApplicantSkillsByApplicantId(int applicantId);

        /// <summary>
        /// get a list of applicant skills by skill id
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns>list of ApplicantSkill objects</returns>
        Task<List<ApplicantSkill>> GetApplicantSkillsBySkillId(int skillId);

        /// <summary>
        /// remove an applicant skill from the data base by applicant skill id
        /// </summary>
        /// <param name="applicantSkillId"></param>
        /// <returns>ApplicantSkill object</returns>
        Task<ApplicantSkill> DeleteApplicantSkill(int applicantSkillId);

    }

}
