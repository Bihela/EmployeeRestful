﻿using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Api.Models
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly AppDbContext _appDbContext;

		public EmployeeRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<Employee> AddEmployee(Employee employee)
		{
			var result = await _appDbContext.Employees.AddAsync(employee);
			await _appDbContext.SaveChangesAsync();
			return result.Entity;
		}

		public async Task DeleteEmployee(int employeeId)
		{
			var employee = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
			if (employee != null)
			{
				_appDbContext.Employees.Remove(employee);
				await _appDbContext.SaveChangesAsync();
			}
		}

		public async Task<Employee> GetEmployee(int employeeId)
		{
			return await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
		}

		public async Task<IEnumerable<Employee>> GetEmployees()
		{
			return await _appDbContext.Employees.ToListAsync();
		}

		public async Task<Employee> UpdateEmployee(Employee employee)
		{
			var existingEmployee = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
			if (existingEmployee != null)
			{
				existingEmployee.FirstName = employee.FirstName;
				existingEmployee.LastName = employee.LastName;
				existingEmployee.Email = employee.Email;
				existingEmployee.DateOfBirth = employee.DateOfBirth;
				existingEmployee.Gender = employee.Gender;
				existingEmployee.DepartmentId = employee.DepartmentId;

				await _appDbContext.SaveChangesAsync();

				return existingEmployee;
			}

			return null;
		}
	}
}