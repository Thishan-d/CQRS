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

        public async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(x => x.EmpId == id);
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployee(Employee player)
        {
            _context.Employees.Remove(player);
            return await _context.SaveChangesAsync();
        }

    }
}
