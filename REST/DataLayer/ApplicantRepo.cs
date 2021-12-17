﻿using Microsoft.EntityFrameworkCore;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace REST.DataLayer
{
    public class ApplicantRepo : IApplicantRepo
    {
        private readonly BatchesDBContext _context;
        public ApplicantRepo(BatchesDBContext context)
        {
            _context = context;
        }
        public async Task<Applicant> AddApplicant(Applicant applicant)
        {
            await _context.Applicants.AddAsync(applicant);
            await _context.SaveChangesAsync();

            return applicant;
        }


        public async Task<List<Applicant>> GetApplicants()
        {
            return await _context.Applicants.AsNoTracking().Select(ap => ap).ToListAsync();
        }

        public async Task<Applicant> GetApplicantById(int id)
        {
            return await _context.Applicants.FirstOrDefaultAsync(ap => ap.ApplicantId == id);
        }

        public async Task<Applicant> UpdateApplicant(Applicant applicant)
        {
            if (_context.Applicants.Where(ap => ap.ApplicantId == applicant.ApplicantId).Select(x => x).Count() == 1) // id exists
            {
                _context.Applicants.Update(applicant);
                await _context.SaveChangesAsync();
                return applicant;
            }
            return null;
        }

        public async Task<Applicant> DeleteApplicantById(int applicantId)
        {
            Applicant applicant = await _context.Applicants.FirstOrDefaultAsync(ap => ap.ApplicantId == applicantId);
            if(applicant != null)
            {
                _context.Applicants.Remove(applicant);
                await _context.SaveChangesAsync();
            }

            return applicant;
        }
    }
}
