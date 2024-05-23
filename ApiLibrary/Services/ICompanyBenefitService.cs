using ApiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Services
{
    public interface ICompanyBenefitService
    {
        Task<CompanyBenefits> CreateCompanyBenefit(CompanyBenefits companyBenefit);
        Task<string> DeleteCompanyBenefit(int companyId, int id);
    }
}
