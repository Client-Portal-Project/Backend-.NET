using Microsoft.EntityFrameworkCore;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.DataLayer
{
    public class TopicRepo : ITopicRepo
    {
        private readonly BatchesDBContext _context;
        public TopicRepo(BatchesDBContext context)
        {
            _context = context;
        }

        public async Task<Topic> AddTopic(Topic topics)
        {
            await _context.Topics.AddAsync(topics);
            await _context.SaveChangesAsync();
            return topics;
        }

        public async Task<List<Topic>> GetTopics()
        {
            return await _context.Topics.AsNoTracking().Select(tp => tp).ToListAsync();
        }

        public async Task<Topic> GetTopicsById(int Id)
        {
            return await _context.Topics.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Topic> UpdateTopics(Topic topic)
        {
            if (_context.Topics.Where(t => t.Id == topic.Id).Select(x => x).Count() == 1) // id exists
            {
                _context.Topics.Update(topic);
                await _context.SaveChangesAsync();
                return topic;
            }
            return null;
        }

        public async Task<Topic> DeleteTopicById(int Id)
        {
            Topic topic = await _context.Topics.FirstOrDefaultAsync(t => t.Id == Id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
            }
            return topic;
        }

        public async Task<OccupationsTopicsJoin> AddTopicToOccupation(int topicId, int OccupationId)
        {
            OccupationsTopicsJoin join = new OccupationsTopicsJoin();

            OccupationsTopicsJoin alreadyExists = await _context.OccupationsTopicsJoins.FirstOrDefaultAsync(a => a.TopicsId == topicId && a.OccupationsId == OccupationId);

            if (alreadyExists == null)
            {
                Topic topic = await GetTopicsById(topicId);
                Occupation Occupation = await _context.Occupations.FirstOrDefaultAsync(c => c.Id == OccupationId);

                if (topic != null && Occupation != null)
                {
                    join.Occupations = Occupation;
                    join.Topics = topic;
                    await _context.OccupationsTopicsJoins.AddAsync(join);
                    await _context.SaveChangesAsync();
                }
            }

            return join;

        }
    }
}
