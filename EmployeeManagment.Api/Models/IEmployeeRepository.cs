using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagment.Api.Models
{
	public interface IEmployeeRepository
	{
		Task<IEnumerable<Employee>> GetEmployees();
		Task<Employee> GetEmployee(int employeeId);
		Task<Employee> GetEmployeeByEmail(string email);
		Task<Employee> AddEmployee(Employee employee); // Add this line
		Task<Employee> UpdateEmployee(Employee employee);
		Task DeleteEmployee(int employeeId);
	}
}
