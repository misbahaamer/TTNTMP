using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;

namespace TTNtmp.Models
{
    public class VendorPositionStatus
    {
        public int Id { get; set; }

        [Required]
        public string StatusType { get; set; }

        public string Description { get; set; }
    }
}
