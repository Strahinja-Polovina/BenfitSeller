using ApiLibrary.Models;

namespace ApiLibrary.Services
{
    public interface IBenefitService
    {
        Task<List<Benefit>> GetAllBenefits();
        Task<Benefit> GetBenefitById(int id);
        Task<Benefit> CreateBenefit(Benefit benefit);
        Task<Benefit> UpdateBenefit(int id, Benefit benefit);
        Task<string> DeleteBenefit(int id);
    }
}
