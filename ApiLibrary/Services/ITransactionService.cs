using ApiLibrary.Models;


namespace ApiLibrary.Services
{
    public interface ITransactionService
    {
        Task<List<Transactions>> GetTransactions();
    }
}
