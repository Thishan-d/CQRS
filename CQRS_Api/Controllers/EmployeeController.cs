using CQRS_Api.Features.Employees.Commands;
using CQRS_Api.Features.Employees.Queries;
using CQRS_Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeQueryModel>> GetEmployees()
        {
            return await _mediator.Send(new GetAllEmployeesQuery());
        }

        [HttpGet("{empId:int}")]
        public async Task<EmployeeQueryModel> GetEmployee(int empId)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery(empId));
        }

        [HttpPost]
        public async Task<Employee> CreateEmployee([FromBody] EmployeeCommandModel employee)
        {
            return await _mediator.Send(new CreateEmployeeCommand(employee));
        }

        [HttpPut]
        public async Task<int> UpdateEmployee([FromBody] EmployeeCommandModel employee)
        {
            return await _mediator.Send(new UpdateEmployeeCommand(employee));
        }

        [HttpDelete("{empId:int}")]
        public async Task<int> DeleteEmployee(int empId)
        {
            return await _mediator.Send(new DeleteEmployeeCommand(empId));
        }
    }
}
