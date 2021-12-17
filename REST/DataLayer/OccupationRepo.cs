using Microsoft.EntityFrameworkCore;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.DataLayer
{
    public class OccupationRepo : IOccupationRepo
    {
        private readonly BatchesDBContext _context;
        public OccupationRepo(BatchesDBContext context)
        {
            _context = context;
        }


        public async Task<List<Occupation>> GetOccupations()
        {
            return await _context.Occupations.AsNoTracking().Select(c => c).ToListAsync();
        }

        public async Task<Occupation> AddOccupation(Occupation Occupation)
        {
            await _context.Occupations.AddAsync(Occupation);
            await _context.SaveChangesAsync();
            return Occupation;
        }

        public async Task<Occupation> FindOccupationById(int OccupationId)
        {
            return await _context.Occupations.FirstOrDefaultAsync(c => c.Id == OccupationId);
        }

        public async Task<Occupation> FindOccupationByName(string OccupationName)
        {


            return await _context.Occupations.FirstOrDefaultAsync(c => c.OccupationName == OccupationName);

        }

        public async Task<Occupation> UpdateOccupations(Occupation occupation)
        {
            if (_context.Occupations.Where(o => o.Id == occupation.Id).Select(x => x).Count() == 1) // id exists
            {
                _context.Occupations.Update(occupation);
                await _context.SaveChangesAsync();
                return occupation;
            }
            return null;
        }

        public async Task<Occupation> DeleteOccupationById(int OccupationId)
        {
            Occupation Occupation = await _context.Occupations.FirstOrDefaultAsync(c => c.Id == OccupationId);
            if(Occupation != null)
            {
                _context.Occupations.Remove(Occupation);
                await _context.SaveChangesAsync();
            }

            return Occupation;
        }

        public async Task<List<Occupation>> GetOccupationsByTag(int topicId)
        {
            var list = await _context.OccupationsTopicsJoins.AsNoTracking().Select(c => c).Where(t => t.TopicsId == topicId).ToListAsync();

            List<Occupation> Occupations = new List<Occupation>();
            foreach (var x in list)
            {
                var Occupation = await FindOccupationById(x.OccupationsId);
                Occupations.Add(Occupation);
            }

            return Occupations;
        }
    }
}
