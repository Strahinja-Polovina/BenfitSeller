using ApiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Services
{
    public interface ICompanyMerchantDiscountService
    {
        Task<CompanyMerchantsDiscounts> CreateCompanyMerchantDiscount(CompanyMerchantsDiscounts companyBenefit);
        Task<string> DeleteCompanyMerchantDiscount(int companyId, int id);
    }
}
