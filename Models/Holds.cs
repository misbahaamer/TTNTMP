using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;

namespace TTNtmp.Models
{
    public class Holds
    {
        public int Id { get; set; }
        public virtual VendorPosition VendorPosition { get; set; }
        public virtual EmployeeCard EmployeeCard { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
