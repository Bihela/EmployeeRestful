using Microsoft.AspNetCore.Components;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Web.Components.Pages
{
	public class EmployeeListBase : ComponentBase
	{
		public IEnumerable<Employee> Employees { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await Task.Run(LoadEmployees);

		}

		protected override void OnInitialized()
		{
			LoadEmployees();
		}

		private void LoadEmployees()
		{
			System.Threading.Thread.Sleep(3000);
			Employee e1 = new Employee
			{
				EmployeeId = 1,
				FirstName = "John",
				LastName = "Hastings",
				Email = "David@inteprid.com",
				DateOfBirth = new DateTime(1980, 10, 5),
				Gender = Gender.Male,
				DepartmentId = 1,
				PhotoPath = "images/john.jpg"
			};

			Employee e2 = new Employee
			{
				EmployeeId = 2,
				FirstName = "Alice",
				LastName = "Smith",
				Email = "alice@example.com",
				DateOfBirth = new DateTime(1990, 5, 15),
				Gender = Gender.Female,
				DepartmentId = 2,
				PhotoPath = "images/alice.jpg"
			};

			Employee e3 = new Employee
			{
				EmployeeId = 3,
				FirstName = "Bob",
				LastName = "Johnson",
				Email = "bob@example.com",
				DateOfBirth = new DateTime(1985, 8, 25),
				Gender = Gender.Male,
				DepartmentId = 3,
				PhotoPath = "images/bob.jpg"
			};

			Employee e4 = new Employee
			{
				EmployeeId = 4,
				FirstName = "Emily",
				LastName = "Davis",
				Email = "emily@example.com",
				DateOfBirth = new DateTime(1995, 12, 10),
				Gender = Gender.Female,
				DepartmentId = 4,
				PhotoPath = "images/emily.jpg"
			};

			Employees = new List<Employee> { e1, e2, e3, e4 };
		}
	}
}
