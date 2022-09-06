using CQRS_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_Api.Services
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(EmployeeCommandModel employee);
        Task<int> DeleteEmployee(int empId);
        Task<int> UpdateEmployee(EmployeeCommandModel employee);
        Task<EmployeeQueryModel> GetEmployeeById(int id);
        Task<IEnumerable<EmployeeQueryModel>> GetEmployeeList();
    }
}