using AutoMapper;
using TTNtmp.Models;
using TTNtmp.Controllers;
using TTNtmp.Controllers.Resources;

namespace TTNtmp.Controllers.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeResource>();
            
        }
    }
}