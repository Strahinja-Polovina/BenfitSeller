using ApiLibrary.Data;
using ApiLibrary.Models;
using BaseLibrary.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Services
{
    public class EmployeeService(ApplicationDbContext db) : IEmployeeService
    {
        private readonly ApplicationDbContext _db = db;
        public async Task<Employee> CreateEmployee(Employee employee)
        {

            Company? dbCompany = await _db.Companies.FirstOrDefaultAsync(c => c.Id == employee.CompanyId) ?? throw new KeyNotFoundException("Company not found");

            EntityEntry<Employee> newEmployeeEntry = await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();


            return newEmployeeEntry.Entity;

        }

        public async Task<string> DeleteEmployee(int CompanyId, int EmployeeId)
        {
            Company? dbCompany = await _db.Companies.FirstOrDefaultAsync(c => c.Id == CompanyId) ?? throw new KeyNotFoundException("Company not found");

            Employee? dbEmployee = await _db.Employees.FirstOrDefaultAsync(e => e.Id == EmployeeId && e.CompanyId == CompanyId) ?? throw new KeyNotFoundException("Employee not found");

            _db.Employees.Remove(dbEmployee);
            await _db.SaveChangesAsync();

            return $"Employee with id {EmployeeId} deleted successfully";
        }
    }
}
