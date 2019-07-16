using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;
using TTNtmp.Persistence;

namespace TTNtmp.Controllers
{
    public class VendorPositionService : IVendorPosition
    {
        private TTNtmpDbContext  _context;
        public VendorPositionService(TTNtmpDbContext context)
        {
            _context = context;
        }

        public void Add(VendorPosition newPosition)
        {
            _context.Add(newPosition);
            _context.SaveChanges();
        }


        public IEnumerable<VendorPosition> GetAll()
        {
            return _context.VendorPositions
                .Include(position => position.Status)
                .Include(position => position.Location);
        }

        public float GetBillRate(int Id)
        {
            throw new NotImplementedException();
        }

        public VendorPosition GetById(int Id)
        {
            return GetAll()
                .FirstOrDefault(position => position.Id ==Id);
        }

        public string GetClientID(int Id)
        {
            if (_context.VendorClients.Any(client => client.Id == Id))
            {
                return _context.VendorClients.FirstOrDefault(client => client.Id == Id).ClientID;
            }
            
            else return "";
        }

        public string ClientName(int Id)
        {
            if (_context.VendorClients.Any(a => a.Id == Id))
            {
                return _context.VendorClients
                    .FirstOrDefault(a => a.Id == Id).ClientName;
            }
            else return "";
        }

        public Vendors GetLocation(int Id)
        {
            return GetById(Id).Location;
        }

        public int GetNoOfRequirements(int Id)
        {
            return GetById(Id).NoOfRequirements;
        }

        public string GetPositionUrl(int Id)
        {
            if (_context.VendorClients.Any(a => a.Id == Id))
            {
                return _context.VendorClients
                    .FirstOrDefault(a => a.Id == Id).PositionUrl;
            }
            else return "";
        }

        public string GetStatus(int Id)
        {
            if (_context.VendorClients.Any(a => a.Id == Id))
            {
                return _context.VendorClients
                    .FirstOrDefault(a => a.Id == Id).Status;
            }
            else return "";
        }

        public string GetTitle(int Id)
        {
            return _context.VendorClients
                    .FirstOrDefault(a => a.Id == Id).Title;
        }
    }

        
    
}
