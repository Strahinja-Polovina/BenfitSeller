using ApiLibrary.Models;
using BaseLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Services
{
    public interface IEmployeeService
    {
        public Task<Employee> CreateEmployee(Employee employee);
        public Task<string> DeleteEmployee(int CompanyId,int EmployeeId);
    }
}
