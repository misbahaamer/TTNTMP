using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;

namespace TTNtmp.Models
{
    public abstract class VendorPosition
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Status { get; set; }

        public float BillRate { get; set; }

        public string PositionUrl { get; set; }

        public int NoOfRequirements { get; set; }

        public virtual Vendors Location { get; set; }
    }
}
