using CQRS_Api.Models;
using CQRS_Api.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Api.Features.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpAge { get; set; }
        public int EmpSalary { get; set; }

        public UpdateEmployeeCommand(EmployeeCommandModel employee)
        {
            this.EmpName = employee.EmpName;
            this.EmpAge = employee.EmpAge;
            this.EmpId = employee.EmpId;
            this.EmpSalary = employee.EmpSalary;
        }
        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private readonly IEmployeeService _employeeService;
            public UpdateEmployeeCommandHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }
            public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = new EmployeeCommandModel();

                employee.EmpAge = request.EmpAge;
                employee.EmpName = request.EmpName;
                employee.EmpSalary = request.EmpSalary;
                employee.EmpId = request.EmpId;

                return await _employeeService.UpdateEmployee(employee);
            }
        }
    }
}
