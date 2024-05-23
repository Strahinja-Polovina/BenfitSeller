using ApiLibrary.Models;
using ApiLibrary.Services;
using AutoMapper;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController(IMerchantService merchantService, IMapper mapper) : Controller
    {
        private readonly IMerchantService _merchantService = merchantService;
        private readonly IMapper _mapper = mapper;

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetMerchants()
        {
            try
            {
                List<Merchant> merchants = await _merchantService.GetAllMerchants();
       
                return Ok(merchants);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMerchant(int id)
        {
            try
            {
                Merchant merchant = await _merchantService.GetMerchantById(id);
                return Ok(merchant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateMerchant([FromBody] ICreateMerchantDTO merchantDTO)
        {
            try
            {
                Merchant merchant = _mapper.Map<Merchant>(merchantDTO);
                Merchant response = await _merchantService.CreateMerchant(merchant);

                response = await _merchantService.GetMerchantById(response.Id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMerchant(int id, [FromBody] IUpdateMerchantDTO merchantDTO)
        {
            try
            {
                Merchant merchant = _mapper.Map<Merchant>(merchantDTO);
                Merchant response = await _merchantService.UpdateMerchant(id, merchant);
                response = await _merchantService.GetMerchantById(response.Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchant(int id)
        {
            try
            {
                string response = await _merchantService.DeleteMerchant(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
