﻿using EmployeeManagement.Models;

namespace EmployeeManagment.Api.Models
{
	public interface IEmployeeRepository
	{
		Task<IEnumerable<Employee>> GetEmployees();
		Task<Employee> GetEmployee(int employeeId);
		Task<Employee> AddEmployee(Employee employee);
		Task<Employee> UpdateEmployee(Employee employee);

		Task DeleteEmployee(int employeeId);

	}
}