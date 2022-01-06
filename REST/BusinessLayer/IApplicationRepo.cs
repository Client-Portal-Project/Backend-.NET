using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.BusinessLayer
{
    public interface IApplicationRepo
    {
        /// <summary>
        /// get all the applications in the database
        /// </summary>
        /// <returns>List of applications</returns>
        public Task<List<Application>> GetApplications();


        /// <summary>
        /// add a new application into the Database
        /// </summary>
        /// <param name="application"></param>
        /// <returns>Application object</returns>
        public Task<Application> AddAnApplication(Application application);

        /// <summary>
        /// updates an application in the database
        /// </summary>
        /// <param name="application"></param>
        /// <returns>application object or null if no object found</returns>
        public Task<Application> UpdateApplications(Application application);

        /// <summary>
        /// get an application by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Application object</returns>
        public Task<Application> GetApplicationsById(int id);

        /// <summary>
        /// remove an application from the data base by its id
        /// </summary>
        /// <param name="ApplicationId"></param>
        /// <returns>Application object</returns>
        public Task<Application> DeleteAnApplicationById(int ApplicationId);
    }
}
