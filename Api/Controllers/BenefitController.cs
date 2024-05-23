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
    [Authorize(Policy = "Admin")]
    public class BenefitController : ControllerBase
    {
        private readonly IBenefitService _categoryService;
        private readonly IMapper _mapper;

        public BenefitController(IBenefitService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBenefits()
        {
            try
            {
                List<Benefit> benefits = await _categoryService.GetAllBenefits();
                return Ok(benefits);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBenefit(int id)
        {
            try
            {
                Benefit benefit = await _categoryService.GetBenefitById(id);
                return Ok(benefit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBenefit([FromBody] IBenefitDTO benefitDTO)
        {
          
            try
            {
                Benefit benefit = _mapper.Map<Benefit>(benefitDTO);
                Benefit response = await _categoryService.CreateBenefit(benefit);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBenefit(int id, [FromBody] IBenefitDTO benefitDTO)
        {
            try
            {
                Benefit benefit = _mapper.Map<Benefit>(benefitDTO);
                Benefit response = await _categoryService.UpdateBenefit(id, benefit);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBenefit(int id)
        {
            try
            {
                string response = await _categoryService.DeleteBenefit(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
