using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Api.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public int EmpAge { get; set; }

        //Only for Command
        public int EmpSalary { get; set; }
    }
}
