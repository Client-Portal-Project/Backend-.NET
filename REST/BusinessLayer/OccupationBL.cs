using REST.DataLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.BusinessLayer
{
    public class OccupationBL:IOccupationBL
    {
        private readonly IOccupationRepo _Occupationrepo;
        public OccupationBL(IOccupationRepo Occupationrepo)
        {
            _Occupationrepo = Occupationrepo;
        }

        public async Task<Occupation> AddOccupation(Occupation c)
        {
            return await _Occupationrepo.AddOccupation(c);
        }

        public async Task<Occupation> FindOccupationById(int OccupationID)
        {
            return await _Occupationrepo.FindOccupationById(OccupationID);
        }

        public async Task<Occupation> FindOccupationByName(string OccupationName)
        {
            return await _Occupationrepo.FindOccupationByName(OccupationName);
        }

        public async Task<List<Occupation>> GetOccupations()
        {
            return await _Occupationrepo.GetOccupations();
        }

        public async Task<Occupation> UpdateOccupations(Occupation Occupation)
        {
            return await _Occupationrepo.UpdateOccupations(Occupation);
        }

        public async Task<Occupation> DeleteOccupationById(int OccupationId)
        {
            return await _Occupationrepo.DeleteOccupationById(OccupationId);
        }

        public async Task<List<Occupation>> GetOccupationsByTag(int topicId)
        {
            return await _Occupationrepo.GetOccupationsByTag(topicId);
        }

    }
}
