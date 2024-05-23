using ApiLibrary.Data;
using ApiLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiLibrary.Services
{
    public class CompanyMerchantDiscountService(ApplicationDbContext db) : ICompanyMerchantDiscountService
    {
        private readonly ApplicationDbContext _db = db;
        async Task<CompanyMerchantsDiscounts> ICompanyMerchantDiscountService.CreateCompanyMerchantDiscount(CompanyMerchantsDiscounts companyBenefit)
        {
            Company? dbCompany = await _db.Companies.FirstOrDefaultAsync(c => c.Id == companyBenefit.CompanyId) ?? throw new Exception("Company not found");
            Merchant? dbMerchantService = await _db.Merchants.FirstOrDefaultAsync(ms => ms.Id == companyBenefit.MerchantId) ?? throw new Exception("Merchant service not found");
            CompanyMerchantsDiscounts? dbCompanyMerchantDiscount = await _db.CompanyMerchantsDiscounts.FirstOrDefaultAsync(cb => cb.CompanyId == companyBenefit.CompanyId && cb.MerchantId == companyBenefit.MerchantId);
            if (dbCompanyMerchantDiscount != null)
            {
                throw new Exception("Company merchant discount already exists");
            }

            await _db.CompanyMerchantsDiscounts.AddAsync(companyBenefit);
            await _db.SaveChangesAsync();
            return companyBenefit;
        }

        Task<string> ICompanyMerchantDiscountService.DeleteCompanyMerchantDiscount(int companyId, int id)
        {
            Company? dbCompany = _db.Companies.FirstOrDefault(c => c.Id == companyId) ?? throw new Exception("Company not found");
            Merchant? dbMerchantService = _db.Merchants.FirstOrDefault(ms => ms.Id == id) ?? throw new Exception("Merchant service not found");
            CompanyMerchantsDiscounts? dbCompanyMerchantDiscount = _db.CompanyMerchantsDiscounts.FirstOrDefault(cb => cb.CompanyId == companyId && cb.MerchantId == id) ?? throw new Exception("Company merchant discount not found");
            _db.CompanyMerchantsDiscounts.Remove(dbCompanyMerchantDiscount);
            _db.SaveChanges();
            return Task.FromResult($"Company merchant discount with id {id} deleted successfully");
        }
    }
}
