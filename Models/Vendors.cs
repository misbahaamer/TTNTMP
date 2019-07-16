using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;

namespace TTNtmp.Models
{
    public class Vendors
    {
        
        public int Id { get; set; }

        [Required]
        public string VendorName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage ="10 digits phone number required")]
        public string VendorPhone { get; set; }

        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<Employee> Employees { get; set; }
        public virtual IEnumerable<VendorPosition> VendorPositions { get; set; }

        public string PositionUrl { get; set; }
    }
}
