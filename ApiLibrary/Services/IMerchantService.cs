using ApiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Services
{
    public interface IMerchantService
    {
        Task<List<Merchant>> GetAllMerchants();
        Task<Merchant> GetMerchantById(int id);
        Task<Merchant> CreateMerchant(Merchant merchant);
        Task<Merchant> UpdateMerchant(int id, Merchant merchant);
        Task<string> DeleteMerchant(int id);
    }
}
