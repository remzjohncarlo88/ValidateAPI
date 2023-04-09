using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Applicant
    {
        [DisplayName("FirstName")]
        public string? FirstName { get; set; }

        [DisplayName("LastName")]
        public string? LastName { get; set; }

        [DisplayName("Email")]
        public string? Email { get; set; }

        [DisplayName("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [DisplayName("BusinessNumber")]
        public int BusinessNumber { get; set; }

        [DisplayName("LoanAmount")]
        public int LoanAmount { get; set; }

        [DisplayName("CitizenshipStatus")]
        public string? CitizenshipStatus { get; set; }

        [DisplayName("TimeTrading")]
        public int TimeTrading { get; set; }

        [DisplayName("CountryCode")]
        public string? CountryCode { get; set; }

        [DisplayName("Industry")]
        public string? Industry { get; set; }
    }
}
