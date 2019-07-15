using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TTNtmp.Models;
using TTNtmp.Persistence;
using TTNtmp.Controllers.Resources;

namespace TTNtmp.Controllers {
    public class EmployeesController : Controller {
        private readonly TTNtmpDbContext context;
        private readonly IMapper mapper;
        public EmployeesController (TTNtmpDbContext context, IMapper mapper) {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet ("/apt/Employees")]
        public async Task<DbSet<EmployeeResource>> GetEmployeesAsync () {
            var employees =   context.Employees;
            return mapper.Map<List<Employee>, List<EmployeeResource>>(employees);
        }
    }
}