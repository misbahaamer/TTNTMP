using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTNtmp.Catalogs
{
    public class PositionIndexListingModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public float BillRate { get; set; }

        public string PositionUrl { get; set; }

        public int NoOfRequirements { get; set; }

    }
}
