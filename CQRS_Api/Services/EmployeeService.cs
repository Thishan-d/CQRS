using CQRS_Api.Context;
using CQRS_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DatabaseContext _context;

        public EmployeeService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeQueryModel>> GetEmployeeList()
        {
            List<Employee> result = await _context.Employees.ToListAsync();
            List<EmployeeQueryModel> empQ = new List<EmployeeQueryModel>();
            if(result!=null)
            {
                foreach (var emp in result)
                {
                    EmployeeQueryModel employee = new EmployeeQueryModel();
                    employee.EmpFirstName = emp.EmpFirstName;
                    employee.EmpAge = emp.EmpAge;
                    employee.EmpId = emp.EmpId;
                    employee.EmpSalary = emp.EmpSalary;
                    empQ.Add(employee);
                }
            }
            return empQ;
        }

        public async Task<EmployeeQueryModel> GetEmployeeById(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
            if (result == null) return default;

            EmployeeQueryModel employee = new EmployeeQueryModel();
            employee.EmpFirstName = result.EmpFirstName;
            employee.EmpAge = result.EmpAge;
            employee.EmpId = result.EmpId;
            return employee;
        }

        public async Task<Employee> CreateEmployee(EmployeeCommandModel employee)
        {
            Employee emp = new Employee();
            emp.EmpAge = employee.EmpAge;
            emp.EmpFirstName = employee.EmpFirstName;
            emp.EmpLastName = employee.EmpLastName;
            emp.EmpSalary = employee._empSalary;
            var result = _context.Employees.Add(emp);
            await _context.SaveChangesAsync();

            return emp;
        }

        public async Task<int> UpdateEmployee(EmployeeCommandModel employee)
        {
            var tempEmp = await _context.Employees.FirstOrDefaultAsync(x => x.EmpId == employee.EmpId);
            tempEmp.EmpSalary= employee._empSalary;
            tempEmp.EmpFirstName = employee.EmpFirstName;
            tempEmp.EmpLastName = employee.EmpLastName;
            _context.Employees.Update(tempEmp);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployee(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if(employee!=null)
            _context.Remove(employee);
            return await _context.SaveChangesAsync();
        }

    }
}
