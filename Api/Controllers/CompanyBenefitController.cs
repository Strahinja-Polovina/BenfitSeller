using ApiLibrary.Models;
using ApiLibrary.Services;
using AutoMapper;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyBenefitController(ICompanyBenefitService companyBenefitService, IMapper mapper, IJwtService jwtService) : Controller
    {
        private readonly ICompanyBenefitService _companyBenefitService = companyBenefitService;
        private readonly IMapper _mapper = mapper;
        private readonly IJwtService _jwtService = jwtService;


        [HttpPost]
        public async Task<IActionResult> CreateCompanyBenefit([FromBody] ICompanyBenefitDTO companyBenefitDTO)
        {
            if(!ModelState.IsValid || companyBenefitDTO.BenefitId <= 0)
            {
                return BadRequest();
            }
        
            int companyId = GetCompanyId();

            CompanyBenefits companyBenefit = _mapper.Map<CompanyBenefits>(companyBenefitDTO);
            companyBenefit.CompanyId = companyId;

            try
            {
                CompanyBenefits newCompanyBenefit = await _companyBenefitService.CreateCompanyBenefit(companyBenefit);
                return Ok($"Benefit added to company successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyBenefit(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            int companyId = GetCompanyId();

            try
            {
                await _companyBenefitService.DeleteCompanyBenefit(companyId, id);
                return Ok("Company benefit deleted successfully");
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
