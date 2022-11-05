using Application.Employees.CreateEmployee;
using Application.Employees.GetEmployees;
using Application.Employees.UpdateEmployee;
using Domain.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            var employees = await _mediator.Send(new GetEmployeesQuery());
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeCommand model)
        {
            await _mediator.Send(model);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand model)
        {
            await _mediator.Send(model);
            return Ok();
        }
    }
}