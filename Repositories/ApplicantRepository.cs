using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        public string CreateApplicant(Applicant applicant)
        {
            return applicant.FirstName;
        }
    }
}
