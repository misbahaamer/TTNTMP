using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace TTNtmp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        

        public ICollection<PersonalInfo> EmployeeInfo { get; set; }

        public  Employee()
        {
            EmployeeInfo = new Collection<PersonalInfo>();
        }
    }
}