using Microsoft.EntityFrameworkCore;
using REST.BusinessLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.DataLayer
{
    public class NeedRepo : INeedRepo
    {
        private readonly BatchesDBContext _context;
        public NeedRepo(BatchesDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// add new need in the Database
        /// </summary>
        /// <param name="need"></param>
        /// <returns>Need object</returns>
        public async Task<Need> AddNeed(Need need)
        {
            await _context.Needs.AddAsync(need);
            await _context.SaveChangesAsync();

            return need;
        }

        /// <summary>
        /// get all the needs in the database
        /// </summary>
        /// <returns>List of needs</returns>
        public async Task<List<Need>> GetNeeds()
        {
            return await _context.Needs.AsNoTracking().Select(n => n).ToListAsync();
        }

        /// <summary>
        /// get a need by need id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Need object</returns>ram>
        /// <returns></returns>
        public Task<Need> GetNeedsById(int Id)
        {
            return _context.Needs.FirstOrDefaultAsync(n => n.NeedId == Id);
        }

        /// <summary>
        /// updates a need's info in the database
        /// </summary>
        /// <param name="need"></param>
        /// <returns>Needs object or null if no object found</returns>
        public async Task<Need> UpdateNeeds(Need need)
        {
            if (_context.Needs.Where(c => c.NeedId == need.NeedId).Select(x => x).Count() == 1) // id exists
            {
                _context.Needs.Update(need);
                await _context.SaveChangesAsync();
                return need;
            }
            return null;
        }

        /// <summary>
        /// remove a need from the data base by need id
        /// </summary>
        /// <param name="needtId"></param>
        /// <returns>Needs object</returns>
        public async Task<Need> DeleteNeedById(int needId)
        {
            Need need = await _context.Needs.FirstOrDefaultAsync(n => n.NeedId == needId);
            if (need != null)
            {
                _context.Needs.Remove(need);
                await _context.SaveChangesAsync();
            }

            return need;
        }
    }
}
