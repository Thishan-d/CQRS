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
/*    public class GetAllEmployeesQuery
    {
    }*/

    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
        {
            private readonly IEmployeeService _employeeService;

            public GetAllEmployeesQueryHandler(IEmployeeService employeesService)
            {
                _employeeService = employeesService;
            }

            public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery query, CancellationToken cancellationToken)
            {
                return await _employeeService.GetEmployeeList();
            }
        }
    }
}
