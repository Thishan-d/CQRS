using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Api.Models
{
    public class EmployeeQueryModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpAge { get; set; }

        //suppose we only read the customer count property, so its only available in Query model
        public int CustomerCount { get; set; }
    }
}
