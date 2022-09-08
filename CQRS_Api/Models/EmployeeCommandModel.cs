using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Api.Models
{
    public class EmployeeCommandModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpAge { get; set; }
        //Suppose we use Emp salary only for create and update. Not for read
        private int EmpSalary { get; set; }

        public int _empSalary 
        {
            get { return EmpSalary; }

            set
            {
                if (value >= 0)
                {
                    EmpSalary = value;
                }
            }
        }
    }
}
