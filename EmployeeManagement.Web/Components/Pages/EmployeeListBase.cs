using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components.Pages
{
	public class EmployeeListBase : ComponentBase
	{
		public IEnumerable<Employee> Employees { get; set; }

	}
	private void LoadEmployees()
	{
		Employee e1 = new Employee
		{
			EmployeeId = 1,
			FirstName = "John",
			LastName = "Hastings",
			Email = "David@inteprid.com",
			DateOfBirth = new DateTime(1980, 10 ,5),
			Gender = Gender.Male,
			Department = New Department { DepartmentId = 1, },
}
