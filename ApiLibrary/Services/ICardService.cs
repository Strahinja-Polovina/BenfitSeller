using ApiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Services
{
    public interface ICardService
    {
        public Task<Card> CreateCard(int companyId, Card card);
        public Task<string> DeleteCard(int companyId, int CardId);
        public Task<string> AddFunds(int companyId, decimal amount, int CardId);
    }
}
