using ApiLibrary.Data;
using ApiLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiLibrary.Services
{
    public class BenefitService(ApplicationDbContext db) : IBenefitService
    {
        private readonly ApplicationDbContext _db = db;

        async Task<Benefit> IBenefitService.CreateBenefit(Benefit benefit)
        {
            Benefit? dbCategry = await _db.Benefits.FirstOrDefaultAsync(b => b.Id == benefit.Id);
            if (dbCategry is not null)
            {
                throw new Exception("Benefit already exists");
            }

            Benefit? newCategory = (await _db.Benefits.AddAsync(benefit)).Entity;
            await _db.SaveChangesAsync();

            return newCategory;
        }

        async Task<string> IBenefitService.DeleteBenefit(int id)
        {
            Benefit? dbCategory = await _db.Benefits.FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception("Benefit not found");
            _db.Benefits.Remove(dbCategory);
            _db.SaveChanges();

            return "Benefit deleted successfully";
        }

        async Task<List<Benefit>> IBenefitService.GetAllBenefits()
        {
            List<Benefit>? categories = await _db.Benefits.ToListAsync();

            return categories;
        }

        async Task<Benefit> IBenefitService.GetBenefitById(int id)
        {
            Benefit? category = await _db.Benefits.FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception("Benefit not found");

            return category;
        }

        async Task<Benefit> IBenefitService.UpdateBenefit(int id, Benefit category)
        {
            Benefit? dbCategory = await _db.Benefits.FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception("Benefit not found");

            if (string.IsNullOrEmpty(category.Name))
            {
                throw new Exception("Benefit name is required");
            }

            dbCategory.Name = category.Name;
            await _db.SaveChangesAsync();
            return dbCategory;
        }
    }
}
