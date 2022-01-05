﻿using Microsoft.EntityFrameworkCore;
using REST.DataLayer.Interfaces;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace REST.DataLayer
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
