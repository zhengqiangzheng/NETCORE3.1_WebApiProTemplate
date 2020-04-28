using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly List<Employee> _employees = new List<Employee>();

        public Task<Employee> Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return Task.Run(() =>
            {
                return employee;
            });
        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(() =>
            {
                var employee = _employees.Where(x => x.Id == id).FirstOrDefault();
                if (employee != null)
                {
                    employee.Fired = true;
                    return employee;
                }
                return null;

            });
        }

        public Task<Employee> GetEmployeeById(int employeeId)
        {
            return Task.Run(() => _employees.Where(x => x.Id == employeeId).FirstOrDefault());

        }

        public Task<IEnumerable<Employee>> GeByDepartmentId(int departmentId)
        {
            return Task.Run(() => _employees.Where(x => x.DepartmentId == departmentId));
        }

        public EmployeeRepository()
        {
            _employees.Add(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FirstName = "Nick",
                LastName = "Carter",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FirstName = "Michael",
                LastName = "Jackson",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 1,
                FirstName = "Mariah",
                LastName = "Carey",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 5,
                DepartmentId = 2,
                FirstName = "Kate",
                LastName = "Winslet",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 6,
                DepartmentId = 2,
                FirstName = "Rob",
                LastName = "Thomas",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 7,
                DepartmentId = 3,
                FirstName = "Avril",
                LastName = "Lavigne",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 8,
                DepartmentId = 3,
                FirstName = "Katy",
                LastName = "Perry",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 9,
                DepartmentId = 3,
                FirstName = "Michelle",
                LastName = "Monaghan",
                Gender = Gender.女
            });

        }

    }
}
