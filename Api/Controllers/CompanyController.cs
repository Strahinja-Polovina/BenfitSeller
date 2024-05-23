using ApiLibrary.Services;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]

    public class CompanyController(ICompanyService companyService) : Controller
    {
        private readonly ICompanyService _companyService = companyService;

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateComapny([FromBody] AddCompanyDTO user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest();
            }
            try
            {
                OCompanyDTO response = await _companyService.CreateCompany(user);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] IUpdateCompanyDTO user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest();
            }
            try
            {
                OCompanyDTO response = await _companyService.UpdateCompany(id, user);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
                        if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                OCompanyDTO response = await _companyService.GetCompanyById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                List<OCompanyDTO> response = await _companyService.GetAllCompanies();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            try
            {
                string response = await _companyService.DeleteCompany(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
