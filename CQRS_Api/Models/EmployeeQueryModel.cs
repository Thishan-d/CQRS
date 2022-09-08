using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Api.Models
{
    public class EmployeeQueryModel
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public int EmpAge { get; set; }
        public int EmpSalary { get; set; }
    }
}
