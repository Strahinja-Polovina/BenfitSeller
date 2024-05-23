using ApiLibrary.Data;
using ApiLibrary.Models;
using ApiLibrary.Services;
using AutoMapper;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyMerchantDiscountController(ApplicationDbContext db, IMapper mapper, IJwtService jwtService, ICompanyMerchantDiscountService companyMerchantDiscountService) : Controller
    {
        private readonly ApplicationDbContext _db = db;
        private readonly IMapper _mapper = mapper;
        private readonly IJwtService _jwtService = jwtService;
        private readonly ICompanyMerchantDiscountService _companyMerchantDiscountService = companyMerchantDiscountService;

        [HttpPost]
        public async Task<IActionResult> AddDiscount([FromBody] ICompanyMerchantDTO companyMerchantDiscountDto)
        {
            var companyId = GetCompanyId();
            Console.WriteLine(companyId);
            if (companyId == 0)
            {
                return Unauthorized();
            }

            try
            {
                var discount = _mapper.Map<CompanyMerchantsDiscounts>(companyMerchantDiscountDto);
                discount.CompanyId = companyId;
                await _companyMerchantDiscountService.CreateCompanyMerchantDiscount(discount);


                await _db.SaveChangesAsync();
                return Ok(_mapper.Map<ICompanyMerchantDTO>(discount));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            try
            {
                var companyId = GetCompanyId();
                if (companyId == 0)
                {
                    return Unauthorized();
                }
                var discount = await _db.CompanyMerchantsDiscounts.FirstOrDefaultAsync(d => d.MerchantId == id && d.CompanyId == companyId);

                if (discount == null)
                {
                    return NotFound("Discount not found");
                }
                if (discount.CompanyId != companyId)
                {
                    return Unauthorized();
                }

                await _companyMerchantDiscountService.DeleteCompanyMerchantDiscount(companyId, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
