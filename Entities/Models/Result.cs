using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Result
    {
        public string? Decision { get; set; }
        public ICollection<ValidationResult> ValidationResult { get; set; }
    }
}
