using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace REST.DataLayer
{
   public interface IApplicantOccupationRepo
    {
        /// <summary>
        /// add new applicant occupation in the Database
        /// </summary>
        /// <param name="applicantOccupation"></param>
        /// <returns>ApplicantOccupation object</returns>
        public Task<ApplicantOccupation> AddApplicantOccupation(ApplicantOccupation applicantOccupation);

        /// <summary>
        /// get all the applicant occupations in the database
        /// </summary>
        /// <returns>List of applicant occupations</returns>
        public Task<List<ApplicantOccupation>> GetApplicantOccupations();

         /// <summary>
         /// updates an applicant occupation's info in the database
         /// </summary>
         /// <param name="applicantOccupation"></param>
         /// <returns>ApplicantOccupation object or null if no object found</returns>
        public Task<ApplicantOccupation> UpdateApplicantOccupation(ApplicantOccupation applicantOccupation);

        /// <summary>
        /// get an applicant occupation by applicant occupation id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ApplicantOccupation object</returns>
        public Task<ApplicantOccupation> GetApplicantOccupationById(int id);

        /// <summary>
        /// get an applicant occupation by applicant id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ApplicantOccupation object</returns>
        public Task<List<ApplicantOccupation>> GetApplicantOccupationByApplicantId(int id);

        /// <summary>
        /// remove an applicant occupation from the data base by applicant occupation id
        /// </summary>
        /// <param name="applicantOccupationId"></param>
        /// <returns>ApplicantOccupation object</returns>
        public Task<ApplicantOccupation> DeleteApplicantOccupationById(int applicantOccupationId);
    }
}
