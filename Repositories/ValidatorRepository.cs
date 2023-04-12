using System;
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
        public IEnumerable<ValidationResult> ValidateApplicant(Applicant applicant, Dictionary<string, string> conditionalDict)
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
            else if (string.IsNullOrEmpty(applicant.PhoneNumber))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.PhoneNumber),
                    Message = "Phone Number is required.",
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
            else if (Convert.ToInt32(conditionalDict["LoanLow"]) <= applicant.LoanAmount 
                && applicant.LoanAmount <= Convert.ToInt32(conditionalDict["LoanHigh"]))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.LoanAmount),
                    Message = string.Concat("Loan Amount must be between $", conditionalDict["LoanLow"], " and $", conditionalDict["LoanHigh"]),
                    Decision = Decision.Unqualified.ToString()
                });
            }
            else if (Convert.ToInt32(conditionalDict["TradingLow"]) <= applicant.TimeTrading
                && applicant.TimeTrading <= Convert.ToInt32(conditionalDict["TradingHigh"]))
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.LoanAmount),
                    Message = string.Concat("Time Trading must be between ", conditionalDict["TradingLow"], " and ", conditionalDict["TradingHigh"]),
                    Decision = Decision.Unqualified.ToString()
                });
            }

            // check if business number is valid
            var task = Task.Run(async () => await CheckBusinessNumber(applicant.BusinessNumber));
            task.Wait();
            if (!task.Result)
            {
                result.Add(new ValidationResult
                {
                    Rule = nameof(applicant.BusinessNumber),
                    Message = "The business number is invalid.",
                    Decision = Decision.Unqualified.ToString()
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

        private async Task<bool> CheckBusinessNumber(int businessNumber)
        {
            await Task.Delay(4000);

            return businessNumber.ToString().Length == 11 ? true : false;
        }
    }
}
