using ApiLibrary.Data;
using ApiLibrary.Helpers;
using ApiLibrary.Models;
using ApiLibrary.Services;
using AutoMapper;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController(IPaymentService paymentService, ApplicationDbContext db, IMapper mapper) : Controller
    {
        private readonly IPaymentService _paymentService = paymentService;
        private readonly ApplicationDbContext _db = db;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> Pay([FromBody] IPayDTO pay)
        {
            if (!ModelState.IsValid || pay == null)
            {
                return BadRequest(ModelState);
            }
            var response = await _paymentService.Pay(pay);
            Transactions transaction = _mapper.Map<Transactions>(response);
            await _db.Transactions.AddAsync(transaction);
            await _db.SaveChangesAsync();


            if (response.Status == Constants.StatusSuccess)
            {
                return Ok(response);
            } else
            {
                return BadRequest(response);
            }
        }
    }
}
