using REST.DataLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the service applies to our entity model, refactor if needed
namespace REST.BusinessLayer
{
    public class ApplicantBL:IApplicantBL
    {
        private readonly IApplicantRepo _applicantRepo;
        private readonly IApplicantSkillRepo _applicantSkillRepo;
        private readonly IApplicantOccupationRepo _applicantOccupationRepo;
        public ApplicantBL(IApplicantRepo applicantRepo, IApplicantSkillRepo applicantSkillRepo, IApplicantOccupationRepo applicantOccupationRepo) {
            _applicantRepo = applicantRepo;
            _applicantSkillRepo = applicantSkillRepo;
            _applicantOccupationRepo = applicantOccupationRepo;
        }

        public async Task<Applicant> AddApplicant(Applicant applicant)
        {
            return await _applicantRepo.AddApplicant(applicant);
        }

        public async Task<List<Applicant>> GetApplicants()
        {
            return await _applicantRepo.GetApplicants();
        }

        public async Task<Applicant> GetApplicantById(int Id)
        {
            return await _applicantRepo.GetApplicantById(Id);
            
        }

        public async Task<Applicant> UpdateApplicant(Applicant applicant)
        {
            return await _applicantRepo.UpdateApplicant(applicant);
        }

        public async Task<Applicant> DeleteApplicantById(int applicantId)
        {
            return await _applicantRepo.DeleteApplicantById(applicantId);
        }

        public async Task<ApplicantOccupation> AddApplicantOccupation(ApplicantOccupation applicantOccupation)
        {
            return await _applicantOccupationRepo.AddApplicantOccupation(applicantOccupation);
        }
        public async Task<List<ApplicantOccupation>> GetApplicantOccupations()
        {
            return await _applicantOccupationRepo.GetApplicantOccupations();
        }
        public async Task<ApplicantOccupation> GetApplicantOccupationById(int applicantOccupationId)
        {
            return await _applicantOccupationRepo.GetApplicantOccupationById(applicantOccupationId);
        }
        public async Task<List<ApplicantOccupation>> GetApplicantOccupationByApplicantId(int applicantId)
        {
            return await _applicantOccupationRepo.GetApplicantOccupationByApplicantId(applicantId);
        }
        public async Task<ApplicantOccupation> UpdateApplicantOccupation(ApplicantOccupation applicantOccupation)
        {
            return await _applicantOccupationRepo.UpdateApplicantOccupation(applicantOccupation);
        }
        public async Task<ApplicantOccupation> DeleteApplicantOccupation(int applicantOccupationId)
        {
            return await _applicantOccupationRepo.DeleteApplicantOccupationById(applicantOccupationId);
        }

        public async Task<ApplicantSkill> AddApplicantSkill(ApplicantSkill applicantSkill)
        {
            return await _applicantSkillRepo.AddApplicantSkill(applicantSkill);
        }
        public async Task<List<ApplicantSkill>> GetApplicantSkillsByApplicantId(int applicantId)
        {
            return await _applicantSkillRepo.GetApplicantSkillsByApplicantId(applicantId);
        }
        public async Task<List<ApplicantSkill>> GetApplicantSkillsBySkillId(int skillId)
        {
            return await _applicantSkillRepo.GetApplicantSkillsBySkillId(skillId);
        }
        public async Task<ApplicantSkill> DeleteApplicantSkill(int applicantSkillId)
        {
            return await _applicantSkillRepo.DeleteApplicantSkillById(applicantSkillId);
        }
    }
}
