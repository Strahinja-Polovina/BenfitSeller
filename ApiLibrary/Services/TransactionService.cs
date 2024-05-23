using ApiLibrary.Data;
using ApiLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace ApiLibrary.Services
{
    public class TransactionService(ApplicationDbContext db) : ITransactionService
    {
        private readonly ApplicationDbContext _db = db;

        async Task<List<Transactions>> ITransactionService.GetTransactions()
        {
            return await _db.Transactions.ToListAsync();
        }
    }
}