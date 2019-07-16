using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTNtmp.Models;

namespace TTNtmp.Models
{
    public class EmployeeCard
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual IEnumerable<Submission> Submissions { get; set; }
    }
}
