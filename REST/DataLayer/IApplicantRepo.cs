using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace REST.DataLayer
{
   public interface IApplicantRepo
    {
        /// <summary>
        /// add new applicant in the Database
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns>Applicant object</returns>
        public Task<Applicant> AddApplicant(Applicant applicant);

        /// <summary>
        /// get all the applicants in the database
        /// </summary>
        /// <returns>List of applicants</returns>
        public Task<List<Applicant>> GetApplicants();

         /// <summary>
         /// updates an applicant's info in the database
         /// </summary>
         /// <param name="applicant"></param>
         /// <returns>Applicant object or null if no object found</returns>
        public Task<Applicant> UpdateApplicant(Applicant applicant);

        /// <summary>
        /// get an applicant by applicant id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Applicant object</returns>
        public Task<Applicant> GetApplicantById(int id);

        /// <summary>
        /// remove an applicant from the data base by applicant id
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns>Applicant object</returns>
        public Task<Applicant> DeleteApplicantById(int applicantId);
    }
}
