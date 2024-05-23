using ApiLibrary.Data;
using ApiLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLibrary.Services
{
    public class CompanyBenefitService : ICompanyBenefitService
    {
        private readonly ApplicationDbContext _db;
        public CompanyBenefitService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CompanyBenefits> CreateCompanyBenefit(CompanyBenefits companyBenefit)
        {
            CompanyBenefits? dbCompanyBenefits = await _db.CompanyBenefits.FirstOrDefaultAsync(cb => cb.CompanyId == companyBenefit.CompanyId && cb.BenefitId == companyBenefit.BenefitId);
            Company? dbCompany = await _db.Companies.FirstOrDefaultAsync(c => c.Id == companyBenefit.CompanyId);
            if (dbCompany == null)
            {
                throw new Exception("Company not found");
            }

            if (dbCompanyBenefits != null)
            {
                throw new Exception("Company benefit already exists");
            }

            await _db.CompanyBenefits.AddAsync(companyBenefit);
            await _db.SaveChangesAsync();
            return companyBenefit;


        }

        public async Task<string> DeleteCompanyBenefit(int companyId, int id)
        {
            CompanyBenefits? dbCompanyBenefits = await _db.CompanyBenefits.FirstOrDefaultAsync(cb => cb.CompanyId == companyId && cb.BenefitId == id);
            if (dbCompanyBenefits == null)
            {
                throw new Exception("Company benefit not found");
            }
            Company? dbCompany = await _db.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
            if (dbCompany == null)
            {
                throw new Exception("Company not found");
            }

            if (dbCompanyBenefits == null)
            {
                throw new Exception("Company benefit already exists");
            }

            _db.CompanyBenefits.Remove(dbCompanyBenefits);
            await _db.SaveChangesAsync();
            return $"Company benefit with id {id} deleted successfully";



        }
    }
}
