using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Enums;
using Entities.Models;

namespace Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private IValidatorRepository _validatorRepository;

        public ApplicantRepository()
        {
            _validatorRepository = new ValidatorRepository();
        }

        public Result CreateApplicant(Applicant applicant, Dictionary<string, string> conditionalDict)
        {
            Result result = new Result();
            // validation of Applicant
            ICollection<ValidationResult> validationResult = _validatorRepository.ValidateApplicant(applicant, conditionalDict).ToList();

            if (validationResult.Any())
            {
               result.Decision = validationResult.Where(x => x.Decision.Equals(Decision.Unknown.ToString())).Any() ? Decision.Unknown.ToString()
                    : validationResult.Where(x => x.Decision.Equals(Decision.Unqualified.ToString())).Any() ? Decision.Unqualified.ToString()
                    : Decision.Qualified.ToString();
                result.ValidationResult = validationResult;
            }
            
            return result;
        }
    }
}
