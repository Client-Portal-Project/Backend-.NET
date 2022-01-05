﻿using Microsoft.EntityFrameworkCore;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace REST.DataLayer
{
    public class ApplicantSkillRepo : IApplicantSkillRepo
    {
        private readonly BatchesDBContext _context;
        public ApplicantSkillRepo(BatchesDBContext context)
        {
            _context = context;
        }
        public async Task<ApplicantSkill> AddApplicantSkill(ApplicantSkill applicantSkill)
        {
            await _context.ApplicantSkills.AddAsync(applicantSkill);
            await _context.SaveChangesAsync();

            return applicantSkill;
        }


        public async Task<List<ApplicantSkill>> GetApplicantSkillsByApplicantId(int applicantId)
        {
            return await _context.ApplicantSkills.AsNoTracking().Select(ap => ap).Where(ap => ap.ApplicantId == applicantId).ToListAsync();
        }

        public async Task<List<ApplicantSkill>> GetApplicantSkillsBySkillId(int skillId)
        {
            return await _context.ApplicantSkills.AsNoTracking().Select(ap => ap).Where(ap => ap.SkillId == skillId).ToListAsync();
        }

        public async Task<ApplicantSkill> DeleteApplicantSkillById(int applicantSkillId)
        {
            ApplicantSkill applicantSkill = await _context.ApplicantSkills.FirstOrDefaultAsync(ap => ap.ApplicantSkillId == applicantSkillId);
            if(applicantSkill != null)
            {
                _context.ApplicantSkills.Remove(applicantSkill);
                await _context.SaveChangesAsync();
            }

            return applicantSkill;
        }
    }
}
