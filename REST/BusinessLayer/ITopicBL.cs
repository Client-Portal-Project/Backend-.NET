using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.BusinessLayer
{
    public interface ITopicBL
    {
        /// <summary>
        /// add new topic in the database
        /// </summary>
        /// <param name="topics"></param>
        /// <returns>Topics object</returns>
        Task<Topic> AddTopic(Topic t);

        /// <summary>
        ///  get a list of all topics in database 
        /// </summary>
        /// <returns>topics list</returns>
        Task<List<Topic>> GetTopics();

        /// <summary>
        /// get a topic by a specific id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Topics object</returns>
        Task<Topic> GetTopicsById(int Id);

        /// <summary>
        /// deletes a topic from the database by topic id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Topics object</returns>
        Task<Topic> DeleteTopicById(int Id);

        /// <summary>
        /// associate an occupation with a topic
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="OccupationId"></param>
        /// <returns>OccupationsTopicsJoin object</returns>
        Task<OccupationsTopicsJoin> AddTopicToOccupation(int topicId, int OccupationId);

    }
}
