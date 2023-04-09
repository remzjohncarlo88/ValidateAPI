using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Applicant
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int BusinessNumber { get; set; }
        public int LoanAmount { get; set; }
        public string? CitizenshipStatus { get; set; }
        public int TimeTrading { get; set; }
        public string? CountryCode { get; set; }
        public string? Industry { get; set; }
    }
}
