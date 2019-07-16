using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Persistence;
using TTNtmp.Catalogs;
using System.ComponentModel.DataAnnotations;

namespace TTNtmp.Controllers
{
    public class VendorPositionController : Controller
    {
        
        private IVendorPosition _positions;
        public VendorPositionController(IVendorPosition positions)
        {
            _positions = positions;
        }
        [HttpGet ("api/VendorPositions")]
        public IActionResult Index()
        {
            var positionModels = _positions.GetAll();
            var ListingResult = positionModels
                .Select(result => new PositionIndexListingModel
                {
                    Id = result.Id,

                    Title = result.Title,

                    Status = result.Status,

                    BillRate = result.BillRate,

                    PositionUrl = result.PositionUrl,

                    NoOfRequirements = result.NoOfRequirements,
                });
            var model = new PositionIndexModel()
            {
                Positions = ListingResult
            };
            return View(model);
            
        }
    }
}
