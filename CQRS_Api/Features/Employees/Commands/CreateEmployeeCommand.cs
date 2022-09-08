using CQRS_Api.Models;
using CQRS_Api.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Api.Features.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public string EmpName { get; set; }
        public int EmpAge { get; set; }
        public int EmpSalary { get; set; }
        public CreateEmployeeCommand(EmployeeCommandModel employee)
        {
            this.EmpName = employee.EmpName;
            this.EmpAge = employee.EmpAge;
            this.EmpSalary = employee._empSalary;
        }
        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
        {
            private readonly IEmployeeService _employeeService;
            public CreateEmployeeCommandHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }
            public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                EmployeeCommandModel employee = new EmployeeCommandModel()
                {
                    EmpName = request.EmpName,
                    EmpAge = request.EmpAge,
                    _empSalary = request.EmpSalary
                };

               return await _employeeService.CreateEmployee(employee);
            }
        }


    }
}
