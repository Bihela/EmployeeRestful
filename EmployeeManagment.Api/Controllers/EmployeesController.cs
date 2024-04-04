using EmployeeManagement.Models;
using EmployeeManagment.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace EmployeeManagment.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository employeeRepository;

		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			this.employeeRepository = employeeRepository;
		}

		[HttpGet]
		public async Task<ActionResult> GetEmployees()
		{
			try
			{
				return Ok(await employeeRepository.GetEmployees());
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
			}
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Employee>> GetEmployee(int id)
		{
			try
			{
				var result = await employeeRepository.GetEmployee(id);
				if (result == null)
				{
					return NotFound();
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
			}
		}

		[HttpPost]
		public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
		{
			try
			{
				if (employee == null)
				{
					return BadRequest("Employee object is null");
				}

				var emp = await employeeRepository.GetEmployeeByEmail(employee.Email);

				if (emp != null)
				{
					ModelState.AddModelError("email", "Employee email already in use");
					return BadRequest(ModelState);
				}

				var createdEmployee = await employeeRepository.AddEmployee(employee);

				return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
			}
			catch (Exception ex)
			{

				return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee");
			}
		}
		[HttpPut("{id:int}")]
		public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
		{
			try
			{
				if (id != employee.EmployeeId)
				{
					return BadRequest("Employee ID mismatch");
				}
				var employeeToUpdate = await employeeRepository.GetEmployee(id);

				if (employeeToUpdate == null)
				{
					return NotFound($"Employee with Id = {id} not found");
				}

				return await employeeRepository.UpdateEmployee(employee);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error updating employee");
			}
		}

	}
}
