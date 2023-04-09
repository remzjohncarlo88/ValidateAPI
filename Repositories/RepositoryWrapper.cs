using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IApplicantRepository _applicantRepository;

        public IApplicantRepository ApplicantRepository
        {
            get { 
                if (_applicantRepository == null)
                {
                    _applicantRepository = new ApplicantRepository();
                }
                return _applicantRepository; 
            }
        }
    }
}
