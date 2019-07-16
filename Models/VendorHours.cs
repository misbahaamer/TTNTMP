using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;

namespace TTNtmp.Models
{
    public class VendorHours
    {
        public int Id { get; set; }

        public Vendors Branch { get; set; }

        public DateTime Date { get; set; }
    }
}
