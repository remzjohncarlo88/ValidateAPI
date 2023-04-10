﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Entities.Enums;

namespace Repositories
{
    public class ValidatorRepository : IValidatorRepository
    {
        private string[] Citizenship = { "Citizen", "PermanentResident" };
        private string[] BannedIndustries = { "Banned Industry 1", "Banned Industry 2" };
        private string[] AllowedIndustries = { "Industry 1", "Industry 2" };
        public IEnumerable<ValidationResult> ValidateApplicant(Applicant applicant)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (string.IsNullOrEmpty(applicant.FirstName))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.FirstName),
                    Message = "First Name is required.",
                    Decision = Decision.Unqualified.ToString()
                });
            }
            else if (string.IsNullOrEmpty(applicant.LastName))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.LastName),
                    Message = "Last Name is required.",
                    Decision = Decision.Unqualified.ToString()
                });
            }
            else if (string.IsNullOrEmpty(applicant.Email))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.Email),
                    Message = "Email is required.",
                    Decision = Decision.Unqualified.ToString()
                });
            }
            else if (!applicant.CountryCode.Equals("AU"))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.CountryCode),
                    Message = "Country Code should be AU.",
                    Decision = Decision.Unqualified.ToString()
                });
            }
            else if (!Citizenship.Contains(applicant.CitizenshipStatus))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.CitizenshipStatus),
                    Message = "Citizenship is invalid.",
                    Decision = Decision.Unqualified.ToString()
                });
            }
            else if (AllowedIndustries.Contains(applicant.Industry))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.Industry),
                    Message = "Industry is allowed.",
                    Decision = Decision.Qualified.ToString()
                });
            }
            else if (BannedIndustries.Contains(applicant.Industry))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.Industry),
                    Message = "Industry is banned.",
                    Decision = Decision.Unqualified.ToString()
                });
            }
            else if (!BannedIndustries.Contains(applicant.Industry) && !AllowedIndustries.Contains(applicant.Industry))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.Industry),
                    Message = "Industry is invalid.",
                    Decision = Decision.Unknown.ToString()
                });
            }
            
            return result;
        }

        private ValidationResult ErrorHandler(string rule, string errorMessage, string decision)
        {
            return (new ValidationResult
            {
                Rule = rule,
                Message = errorMessage,
                Decision = decision
            });
        }
    }
}
