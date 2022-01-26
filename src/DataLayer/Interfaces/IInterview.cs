using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Revisit, ensure the Repo applies to our entity model, refactor if needed
namespace DataLayer
{
    public interface IInterview : IGenericRepo<Interview>
    {
        // methods specific to Client table
    }
}