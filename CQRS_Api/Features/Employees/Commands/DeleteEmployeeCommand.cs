using CQRS_Api.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Api.Features.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int EmpId { get; set; }


        public DeleteEmployeeCommand(int empId)
        {
            this.EmpId = empId;
        }
        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
        {
            private readonly IEmployeeService _employeeService;

            public DeleteEmployeeCommandHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }
            public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await _employeeService.GetEmployeeById(request.EmpId);
                if (employee == null)
                    return default;

                return await _employeeService.DeleteEmployee(employee);
            }
        }
    }
}
