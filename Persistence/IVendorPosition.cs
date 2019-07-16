using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;

namespace TTNtmp.Persistence
{
    public interface IVendorPosition
    {
        IEnumerable<VendorPosition> GetAll();
        VendorPosition GetById(int Id);
        void Add(VendorPosition newPosition);

        string GetTitle(int Id);

        string GetStatus(int Id);

        float GetBillRate(int Id);

        string GetPositionUrl(int Id);

        int GetNoOfRequirements(int Id);

        string GetClientID(int Id);

        string ClientName(int Id);

        Vendors GetLocation(int Id);
    }
}
