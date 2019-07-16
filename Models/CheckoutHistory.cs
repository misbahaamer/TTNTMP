using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;

namespace TTNtmp.Models
{
    public class CheckoutHistory
    {
        public int Id { get; set; }

        [Required]
        public VendorPosition VendorPosition { get; set; }

        [Required]
        public EmployeeCard EmployeeCard { get; set; }

        [Required]
        public DateTime CheckedOutDate { get; set; }
    }
}
