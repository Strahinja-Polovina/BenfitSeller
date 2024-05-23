using ApiLibrary.Data;
using ApiLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class TransactionController(ITransactionService transactionService) : Controller
    {
        private readonly ITransactionService _transactionService = transactionService;
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            return Ok(await _transactionService.GetTransactions());
        }
    }
}
