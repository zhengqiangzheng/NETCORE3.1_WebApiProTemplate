using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace ThreeApi.Repositories
{
    public class SummaryDepository : ISummaryDepository
    {
        private readonly IDepartmentRepository departmentRepository;
        public SummaryDepository(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public Task<CompanySummary> GetCompanySummary()
        {
            var employeesum = departmentRepository.GetAll().Result;
            var averagecount = (int)employeesum.Average(x => x.EmployeeCount);
            return Task.Run(() =>
            {
                return new CompanySummary
                {
                    EmployeeCount = employeesum.Sum(x=>x.EmployeeCount),
                    AverageDepartmentEmployeeCount = averagecount
                };
            });
        }
    }
}
