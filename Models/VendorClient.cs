using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;



namespace TTNtmp.Models
{
    public class VendorClient : VendorPosition
    {
        public string ClientID { get; set; }

        public string ClientName { get; set; }

        public string ClientLocation { get; set; }
    }
}
