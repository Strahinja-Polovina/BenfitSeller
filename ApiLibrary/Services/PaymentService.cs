using ApiLibrary.Data;
using ApiLibrary.Helpers;
using ApiLibrary.Models;
using BaseLibrary.DTO;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ApiLibrary.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _db;

        public PaymentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PaymentResponse> Pay(IPayDTO pay)
        {
            var dbCard = await _db.Cards.FirstOrDefaultAsync(c => c.CardNumber == pay.CardNumber)
                          ?? throw new Exception("Card not found");

            var dbEmployee = await _db.Employees.Include(e => e.Category)
                              .FirstOrDefaultAsync(e => e.Id == dbCard.EmployeeId)
                              ?? throw new Exception("Employee not found");

            var category = dbEmployee.Category!.Name;
            var companyId = dbEmployee.CompanyId;
            Merchant? dbMerchant = await _db.Merchants.FirstOrDefaultAsync(m => m.Id == pay.MerchantId);
                if (dbMerchant == null)
            {
                return new PaymentResponse { Status = Constants.StatusFailed, Amount = pay.Amount, CardNumber = pay.CardNumber, MerchantName = "Merchant not found." };
            }
    

                if (BCrypt.Net.BCrypt.Verify(pay.Pin, dbCard.Pin))
            {
                switch (category)
                {
                    case "Standard Users":
                       
                        int merchantBenefitId = dbMerchant.BenefitId;
                        CompanyBenefits? dbCompanyBenefits = await _db.CompanyBenefits.FirstOrDefaultAsync(cb => cb.CompanyId == companyId && cb.BenefitId == merchantBenefitId);
                        if (dbCompanyBenefits == null)
                        {
                            return new PaymentResponse { Status = Constants.StatusFailed, Amount = pay.Amount, CardNumber = pay.CardNumber, MerchantName = dbMerchant.Name, Message = "Benefit not found." };
                        }
                        if (pay.Amount > dbCard.Balance)
                        {
                            return new PaymentResponse { Status = Constants.StatusFailed, Amount = pay.Amount, CardNumber = pay.CardNumber, MerchantName = dbMerchant.Name, Message = "Not enought balance." };

                        }
                        dbCard.Balance -= pay.Amount;
                        _db.Cards.Update(dbCard);
                        await _db.SaveChangesAsync();
                        return new PaymentResponse { Status = Constants.StatusSuccess, Amount = pay.Amount, CardNumber = pay.CardNumber, MerchantName = dbMerchant.Name, Message = "Payment Successfull" };
           

                    case "Premium Users":
                        if(pay.Amount > dbCard.Balance)
                        {
                            return new PaymentResponse { Status = Constants.StatusFailed, Amount = pay.Amount, CardNumber = pay.CardNumber, MerchantName = dbMerchant.Name, Message = "Not enought balance" };

                        }
                        dbCard.Balance -= pay.Amount;
                        _db.Cards.Update(dbCard);
                        await _db.SaveChangesAsync();
                        return new PaymentResponse { Status = Constants.StatusSuccess, Amount = pay.Amount, CardNumber = pay.CardNumber, MerchantName = dbMerchant.Name, Message = "Payment Successfull." };

                    case "Platinum Users":
                        CompanyMerchantsDiscounts? dbCompanyMerchantDiscouint = await _db.CompanyMerchantsDiscounts.FirstOrDefaultAsync(cmd => cmd.CompanyId == companyId && cmd.MerchantId == pay.MerchantId);
                        if (pay.Amount > dbCard.Balance)
                        {
                            return new PaymentResponse { Status = Constants.StatusFailed, Amount = pay.Amount, CardNumber = pay.CardNumber, MerchantName = dbMerchant.Name, Message = "Not enought balance" };

                        }

                        if (dbCompanyMerchantDiscouint == null)
                        {
                            dbCard.Balance -= pay.Amount;
                            _db.Cards.Update(dbCard);
                            await _db.SaveChangesAsync();
                            return new PaymentResponse { Status = Constants.StatusSuccess, Amount = pay.Amount, CardNumber = pay.CardNumber, MerchantName = dbMerchant.Name, Message = "Payment successfull." };
                        } else
                        {
                            dbCard.Balance -= pay.Amount - (pay.Amount * dbCompanyMerchantDiscouint.Discount / 100);
                            _db.Cards.Update(dbCard);
                            await _db.SaveChangesAsync();
                            return new PaymentResponse { Status = Constants.StatusSuccess, Amount = pay.Amount - (pay.Amount * dbCompanyMerchantDiscouint.Discount / 100), CardNumber = pay.CardNumber, MerchantName = dbMerchant.Name, Message = $"Payment successfull with discount {dbCompanyMerchantDiscouint.Discount}%" };
                        }


                    default:
                        return new PaymentResponse { Status = Constants.StatusFailed, Amount = pay.Amount, CardNumber = pay.CardNumber, MerchantName = dbMerchant.Name, Message = "Category not registered" };

                }


            }
            else
            {
                return new PaymentResponse { Status = Constants.StatusFailed, Amount = pay.Amount, CardNumber = pay.CardNumber, MerchantName = dbMerchant.Name, Message = "Incorrect pin" };

            }
        }
    }
}
