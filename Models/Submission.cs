using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;

namespace TTNtmp.Models
{
    public class Submission
    {
        public int Id { get; set; }

        [Required]
        public VendorPosition VendorPosition { get; set; }

        public EmployeeCard EmployeeCard { get; set; }

        public DateTime OnDate { get; set; }
    }
}
