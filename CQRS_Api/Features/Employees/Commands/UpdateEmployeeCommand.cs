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

        public UpdateEmployeeCommand(Employee employee)
        {
            this.EmpName = employee.EmpName;
            this.EmpAge = employee.EmpAge;
            this.EmpId = employee.EmpId;
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
                var employee = await _employeeService.GetEmployeeById(request.EmpId);
                if (employee == null)
                    return default;

                employee.EmpAge = request.EmpAge;
                employee.EmpName = request.EmpName;

                return await _employeeService.UpdateEmployee(employee);
            }
        }
    }
}
