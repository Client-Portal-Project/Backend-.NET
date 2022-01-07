﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace DataLayer
{
    public class ApplicantOccupationRepo : GenericRepo<ApplicantOccupation>, IApplicantOccupationRepo
    {
        private readonly BatchesDBContext _context;
        public ApplicantOccupationRepo(BatchesDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
