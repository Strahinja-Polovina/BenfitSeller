using ApiLibrary.Data;
using ApiLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Services
{
    public class MerchantService(ApplicationDbContext db) : IMerchantService
    {
        public readonly ApplicationDbContext _db = db;
        async Task<Merchant> IMerchantService.CreateMerchant(Merchant merchant)
        {
            Benefit? benefit = await _db.Benefits.FirstOrDefaultAsync(b => b.Id == merchant.BenefitId) ?? throw new Exception("Benefit not found");
            Merchant? dbMerchant = await _db.Merchants.Include(m => m.Benefit).FirstOrDefaultAsync(m => m.Name == merchant.Name);
            if (dbMerchant is not null)
            {
                throw new Exception("Merchant already exists");
            }

            Merchant? newMerchant = (await _db.Merchants.AddAsync(merchant)).Entity;
            await _db.SaveChangesAsync();

            return newMerchant;
        }

        async Task<string> IMerchantService.DeleteMerchant(int id)
        {
            Merchant? merchant = await _db.Merchants.FirstOrDefaultAsync(m => m.Id == id) ?? throw new Exception("Merchant not found");

            _db.Merchants.Remove(merchant);
            await _db.SaveChangesAsync();

            return $"Merchant {merchant.Name} deleted successfully";
        }

        async Task<List<Merchant>> IMerchantService.GetAllMerchants()
        {
            List<Merchant> merchants = await _db.Merchants.Include(m => m.Benefit).ToListAsync();

            return merchants;
        }

        async Task<Merchant> IMerchantService.GetMerchantById(int id)
        {
            Merchant? merchant = await _db.Merchants.Include(m => m.Benefit).FirstOrDefaultAsync(m => m.Id == id) ?? throw new Exception("Merchant not found");
            return merchant;
        }

        async Task<Merchant> IMerchantService.UpdateMerchant(int id, Merchant merchant)
        {
            Benefit? benefit = await _db.Benefits.FirstOrDefaultAsync(b => b.Id == merchant.BenefitId) ?? throw new Exception("Benefit not found");
            Merchant? dbMerchant = await _db.Merchants.Include(m => m.Benefit).FirstOrDefaultAsync(m => m.Id == id) ?? throw new Exception("Merchant not found");

            if (!string.IsNullOrEmpty(merchant.Name))
            {
                dbMerchant.Name = merchant.Name;
            }

            if (merchant.BenefitId > 0)
            {
                dbMerchant.BenefitId = merchant.BenefitId;
            }

            await _db.SaveChangesAsync();
            return dbMerchant;
        }
    }
}
