using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST.Models;
using REST.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.DataLayer
{
    public class OwnerRepo : IOwnerRepo
    {
        private readonly BatchesDBContext _context;
        public OwnerRepo(BatchesDBContext context)
        {
            _context = context;
        }

/// <summary>
/// Creates an owner. Currently having issues making an owner because of applicant resume
/// causing convering error form JSON to byte[]. **Temp workaround set Appplicant{resume} to null in API test**
/// </summary>
/// <param name="owner"></param>
/// <returns>Owner owner</returns>
        public async Task<Owner> CreateOwnerAsync(Owner owner)
        {
            Console.WriteLine(owner);
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
            return owner;
            //if (owner == null)
            //{
            //    throw new ArgumentNullException(nameof(owner));
            //}else{

            //}
        }

/// <summary>
/// Delete owner by id.
/// </summary>
/// <param name="ownerId"></param>
/// <returns>string validation or error</returns>
        public async Task<string> DeleteOwnerByIdAsync(int ownerId)
        {
            Owner owner = _context.Owners.Find(ownerId);
            if(owner != null){
                _context.Remove(owner);
                await _context.SaveChangesAsync();
                return "Owner deleted";
            }else throw new ArgumentException("Owner not found");
        }

/// <summary>
/// Gets single owner by OwnerId.
/// </summary>
/// <param name="ownerId"></param>
/// <returns>Owner owner</returns>
        public async Task<Owner> GetOwnerByIdAsync(int ownerId)
        {
            Owner owner = await _context.Owners.FirstOrDefaultAsync(o => o.OwnerId == ownerId);
            if(owner == null)
            {
                throw new ArgumentException("Owner not found");
            }else return owner;
        }

/// <summary>
/// Gets all owners.
/// </summary>
/// <returns>List<Owner> owner</returns>
        public async Task<List<Owner>> GetOwnersAsync()
        {
            List<Owner> owners = await _context.Owners.ToListAsync();
            if(owners == null){
                throw new ArgumentException("No owners found");
            } else return (owners);
        }

/// <summary>
/// Updates owner applications.
/// </summary>
/// <param name="owner"></param>
/// <returns>Owner owner</returns>
        public async Task<Owner> UpdateOwnerAsync(Owner owner)
        {
            Owner updatedOwner = await _context.Owners.FirstOrDefaultAsync(o => o.OwnerId == owner.OwnerId);
            if(updatedOwner == null)
            {
                throw new ArgumentException("Owner not found");
            }else{
                updatedOwner.Applications = owner.Applications;
                await _context.SaveChangesAsync();
                return updatedOwner;
            }
        }
    }
}
