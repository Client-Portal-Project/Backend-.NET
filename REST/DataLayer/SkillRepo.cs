
using Microsoft.EntityFrameworkCore;
using REST.DataLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataLayer
{
    public class SkillRepo : ISkillRepo
    {

        private readonly BatchesDBContext _context;
        public SkillRepo(BatchesDBContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            return await _context.Skills.AsNoTracking().Select(s => s).ToListAsync();
        }

        public async Task<List<Skill>> GetSkillsById(int ApplicantId)
        {
            // bc of async this must ve done in stages and cant use a singe linq statement
            List<int> skills = new List<int>();
            var resultFinal = new List<REST.Models.Skill>();
            var result =  await _context.ApplicantSkills.AsNoTracking().Select(a => a)
                         .Where(b => b.ApplicantId == ApplicantId).ToListAsync();
            foreach(ApplicantSkill i in result)
            {
                skills.Add(i.SkillId);
            }         
            foreach(int i in skills)
            {
                resultFinal.Add(await _context.Skills.AsNoTracking().FirstOrDefaultAsync(s => s.SkillId == i));
            }             
            return resultFinal;
        }
        public async Task<Skill> AddSkill(Skill Skill)
        {
            await _context.Skills.AddAsync(Skill);
            await _context.SaveChangesAsync();

            return Skill;
        }

        public async Task<Skill> DeleteSkillById(int SkillId)
        {
            Skill skill = await _context.Skills.FirstOrDefaultAsync(n => n.SkillId == SkillId);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
            }

            return skill;
        }

        public async Task<Skill> UpdateSkills(Skill Skill)
        {
            if (_context.Skills.Where(c => c.SkillId == Skill.SkillId).Select(x => x).Count() == 1) 
            {
                _context.Skills.Update(Skill);
                await _context.SaveChangesAsync();
                return Skill;
            }
            return null;
        }
    }
}


