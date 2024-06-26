﻿using ApiLibrary.Models;
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
    [Authorize(Policy = "Admin")]
    public class MerchantController(IMerchantService merchantService, IMapper mapper) : Controller
    {
        private readonly IMerchantService _merchantService = merchantService;
        private readonly IMapper _mapper = mapper;

    
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMerchant(int id)
        {
                        if (id <= 0)
            {
                return BadRequest("Invalid id");
            }
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


        [HttpPost]
        public async Task<IActionResult> CreateMerchant([FromBody] ICreateMerchantDTO merchantDTO)
        {
                        if (!ModelState.IsValid || merchantDTO == null)
            {
                return BadRequest("Invalid data");
            }
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

    
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMerchant(int id, [FromBody] IUpdateMerchantDTO merchantDTO)
        {
            if (!ModelState.IsValid || merchantDTO == null)
            {
                return BadRequest("Invalid data");
            }
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
            if (id <= 0)
            {
                return BadRequest("Invalid id");
            }
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
