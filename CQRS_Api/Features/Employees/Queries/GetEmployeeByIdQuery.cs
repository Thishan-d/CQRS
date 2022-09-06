using CQRS_Api.Models;
using CQRS_Api.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Api.Features.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeQueryModel>
    {
        public int EmpId { get; set; }
        public GetEmployeeByIdQuery(int empId)
        {
            this.EmpId = empId;
        }
        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeQueryModel>
        {
            private readonly IEmployeeService _employeeService;

            public GetEmployeeByIdQueryHandler(IEmployeeService employeesService)
            {
                _employeeService = employeesService;
            }

            public async Task<EmployeeQueryModel> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
            {
                return await _employeeService.GetEmployeeById(query.EmpId);
            }
        }
    }
}
