using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public readonly List<Department> _departments = new List<Department>();

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(() => _departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(() => _departments.Where(x => x.Id == id).FirstOrDefault());
        }

        Task<Department> IDepartmentRepository.Add(Department department)
        {
            department.Id = _departments.Max(x => x.Id) + 1;
            _departments.Add(department);
            return Task.Run(() =>
             {
                 return department;
             });
        }

        public DepartmentRepository()
        {
            _departments.Add(new Department
            {
                Id = 1,
                Name = "HR",
                EmployeeCount = 16,
                Location = "Beijing"
            });
            _departments.Add(new Department
            {
                Id = 2,
                Name = "RD",
                EmployeeCount = 52,
                Location = "Shanghai"
            });
            _departments.Add(new Department
            {
                Id = 3,
                Name = "Sales",
                EmployeeCount = 200,
                Location = "China"
            });
        }
    }
}
