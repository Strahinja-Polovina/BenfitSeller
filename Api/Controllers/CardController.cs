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
    public class CardController(IMapper mapper, ICardService cardService, IJwtService jwtService) : Controller
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICardService _cardService = cardService;
        private readonly IJwtService _jwtService = jwtService;
        
        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] ICardDTO cardDTO)
        {
            if (!ModelState.IsValid || cardDTO == null)
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
                Card card = _mapper.Map<Card>(cardDTO);
      
                Card cardRes = await _cardService.CreateCard(companyId ,card);
                ICardDTO response = _mapper.Map<ICardDTO>(cardRes);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid card id");
            }
            int companyId = GetCompanyId();
            if (companyId == 0)
            {
                return Unauthorized();
            }
            try
            {
                await _cardService.DeleteCard(companyId, id);
                return Ok("Card deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("AddFunds")]
        public async Task<IActionResult> AddFundsToCard([FromBody]IFundsDTO funds, int employeId)
        {
            if (!ModelState.IsValid || funds == null)
            {
                return BadRequest();
            }

            if (employeId == 0)
            {
                return BadRequest("Invalid employee id");
            }


            int companyId = GetCompanyId();
            if (companyId == 0)
            {
                return Unauthorized();
            }
            try
            {
                await _cardService.AddFunds(companyId, funds.Amount, employeId);
                return Ok("Funds added successfully");
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
