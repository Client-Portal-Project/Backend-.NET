﻿using Microsoft.EntityFrameworkCore;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace REST.DataLayer
{
    public class ApplicantOccupationRepo : IApplicantOccupationRepo
    {
        private readonly BatchesDBContext _context;
        public ApplicantOccupationRepo(BatchesDBContext context)
        {
            _context = context;
        }
        public async Task<ApplicantOccupation> AddApplicantOccupation(ApplicantOccupation applicantOccupation)
        {
            await _context.ApplicantOccupations.AddAsync(applicantOccupation);
            await _context.SaveChangesAsync();

            return applicantOccupation;
        }


        public async Task<List<ApplicantOccupation>> GetApplicantOccupations()
        {
            return await _context.ApplicantOccupations.AsNoTracking().Select(ao => ao).ToListAsync();
        }

        public async Task<ApplicantOccupation> GetApplicantOccupationById(int id)
        {
            return await _context.ApplicantOccupations.FirstOrDefaultAsync(ao => ao.ApplicantOccupationId == id);
        }

        public async Task<List<ApplicantOccupation>> GetApplicantOccupationByApplicantId(int id)
        {
            return await _context.ApplicantOccupations.AsNoTracking().Select(ao=>ao).Where(ao => ao.ApplicantId == id).ToListAsync();
        }

        public async Task<ApplicantOccupation> UpdateApplicantOccupation(ApplicantOccupation applicantOccupation)
        {
            if (_context.ApplicantOccupations.Where(ao => ao.ApplicantOccupationId == applicantOccupation.ApplicantOccupationId).Select(x => x).Count() == 1) // id exists
            {
                _context.ApplicantOccupations.Update(applicantOccupation);
                await _context.SaveChangesAsync();
                return applicantOccupation;
            }
            return null;
        }

        public async Task<ApplicantOccupation> DeleteApplicantOccupationById(int applicantOccupationId)
        {
            ApplicantOccupation applicantOccupation = await _context.ApplicantOccupations.FirstOrDefaultAsync(ao => ao.ApplicantOccupationId == applicantOccupationId);
            if(applicantOccupation != null)
            {
                _context.ApplicantOccupations.Remove(applicantOccupation);
                await _context.SaveChangesAsync();
            }

            return applicantOccupation;
        }
    }
}
