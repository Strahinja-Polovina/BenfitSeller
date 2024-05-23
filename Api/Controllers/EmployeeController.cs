using ApiLibrary.Models;
using ApiLibrary.Services;
using AutoMapper;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController(IEmployeeService employeeService, IMapper mapper, IJwtService jwtService) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly IMapper _mapper = mapper;
        private readonly IJwtService _jwtService = jwtService;

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] IEmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid || employeeDTO == null)
            {
                return BadRequest(ModelState); 
                  }
            int companyId = GetCompanyId();
            if (companyId == 0)
            {
                return Unauthorized();
            }
            try
            {
                Employee employee = _mapper.Map<Employee>(employeeDTO);
                employee.CompanyId = companyId;
                Employee EmployeeRes = await _employeeService.CreateEmployee(employee);
                OEmployeeDTO response = _mapper.Map<OEmployeeDTO>(EmployeeRes);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            int companyId = GetCompanyId();
            if (companyId == 0)
            {
                return Unauthorized();
            }
            try
            {
                await _employeeService.DeleteEmployee(companyId, id);
                return Ok("Employee deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        private int GetCompanyId()
        {
            var authorizationHeader = Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                var parts = authorizationHeader.ToString().Split(" ");
                if (parts.Length == 2 && parts[0].Equals("Bearer", StringComparison.OrdinalIgnoreCase))
                {
                    var token = parts[1];

                    var companyId = _jwtService.GetComapnyFromToken(token)?.Id;
                    if (companyId.HasValue)
                    {
                        return companyId.Value;
                    }
                }
            }
            return 0;
        }
    }
}
