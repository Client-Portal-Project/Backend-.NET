using REST.DataLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.BusinessLayer
{
    public class TopicBL : ITopicBL
    {
        private readonly ITopicRepo _topicRepo;
        public TopicBL(ITopicRepo topicRepo)
        {
            _topicRepo = topicRepo;
        }

        public async Task<Topic> AddTopic(Topic t)
        {
            return await _topicRepo.AddTopic(t);
        }

        public async Task<List<Topic>> GetTopics()
        {
            return await _topicRepo.GetTopics();
        }

        public async Task<Topic> GetTopicsById(int Id)
        {
            return await _topicRepo.GetTopicsById(Id);
        }

        public async Task<Topic> UpdateTopic(Topic t)
        {
            return await _topicRepo.UpdateTopics(t);
        }

        public async Task<Topic> DeleteTopicById(int Id)
        {
            return await _topicRepo.DeleteTopicById(Id);
        }

        public async Task<OccupationsTopicsJoin> AddTopicToOccupation(int topicId, int OccupationId)
        {
            return await _topicRepo.AddTopicToOccupation(topicId, OccupationId);
        }
    }
}
