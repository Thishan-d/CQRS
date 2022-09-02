using CQRS_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_Api.Services
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<int> DeleteEmployee(Employee player);
        Task<int> UpdateEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<Employee>> GetEmployeeList();
    }
}