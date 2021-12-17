using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.BusinessLayer
{
    public interface INeedRepo
    {
        /// <summary>
        /// add new need in the Database
        /// </summary>
        /// <param name="need"></param>
        /// <returns>Need object</returns>
        Task<Need> AddNeed(Need need);

        /// <summary>
        /// get all the needs in the database
        /// </summary>
        /// <returns>List of needs</returns>
        Task<List<Need>> GetNeeds();

        /// <summary>
        /// get a need by need id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Need object</returns>ram>
        /// <returns></returns>
        Task<Need> GetNeedsById(int Id);

        /// <summary>
        /// updates a need's info in the database
        /// </summary>
        /// <param name="need"></param>
        /// <returns>Needs object or null if no object found</returns>
        Task<Need> UpdateNeeds(Need need);

        /// <summary>
        /// remove a need from the data base by need id
        /// </summary>
        /// <param name="needtId"></param>
        /// <returns>Needs object</returns>
        Task<Need> DeleteNeedById(int needId);
    }
}
