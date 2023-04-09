using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ValidationResult
    {
        public string? Rule { get; set; }
        public string? Message { get; set; }
        public string? Decision { get; set; }
    }
}
