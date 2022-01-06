using Microsoft.EntityFrameworkCore;
using REST.BusinessLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.DataLayer
{
    public class ApplicationRepo : IApplicationRepo
    {
        private readonly BatchesDBContext _context;
        public ApplicationRepo(BatchesDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Application
        /// </summary>
        /// <returns></returns>
        public async Task<List<Application>> GetApplications()
        {
            return await _context.Applications.AsNoTracking().Select(apl => apl).ToListAsync();
        }

        /// <summary>
        /// Add an Application
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public async Task<Application> AddAnApplication(Application application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();

            return application;
        }
        /// <summary>
        /// Get specific applications by their Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<Application> GetApplicationsById(int Id)
        {
            return _context.Applications.FirstOrDefaultAsync(apl => apl.ApplicationId == Id);
        }

        /// <summary>
        /// Update a application
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public async Task<Application> UpdateApplications(Application application)
        {
            if (_context.Applications.Where(apl => apl.ApplicationId == application.ApplicationId).Select(x => x).Count() == 1) // id exists
            {
                _context.Applications.Update(application);
                await _context.SaveChangesAsync();
                return application;
            }
            return null;
        }

        /// <summary>
        /// Remove a Client
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns></returns>
        public async Task<Application> DeleteAnApplicationById(int applicationId)
        {
            Application application = await _context.Applications.FirstOrDefaultAsync(apl => apl.ApplicationId == applicationId);
            if (application != null)
            {
                _context.Applications.Remove(application);
                await _context.SaveChangesAsync();
            }

            return application;
        }
    }
}
