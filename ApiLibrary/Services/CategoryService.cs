using ApiLibrary.Data;
using ApiLibrary.Models;
using ApiLibrary.Services;
using Microsoft.EntityFrameworkCore;


namespace ApiLibrary.Service
{
    public class CategoryService(ApplicationDbContext db) : ICategoryService
    {
        private readonly ApplicationDbContext _db = db;

        async Task<Category> ICategoryService.CreateCategory(Category category)
        {
            Category? dbCategry = await _db.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);
            if (dbCategry is not null)
            {
                throw new Exception("Category already exists");
            }

            Category? newCategory = (await _db.Categories.AddAsync(category)).Entity;
            await _db.SaveChangesAsync();

            return newCategory;
        }

        async Task<string> ICategoryService.DeleteCategory(int id)
        {
            Category? dbCategory = await _db.Categories.FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception("Category not found");
            _db.Categories.Remove(dbCategory);
            _db.SaveChanges();

            return "Category deleted successfully";
        }

        async Task<List<Category>> ICategoryService.GetAllCategories()
        {
            List<Category>? categories = await _db.Categories.ToListAsync();

            return categories;
        }

        async Task<Category> ICategoryService.GetCategoryById(int id)
        {
            Category? category = await _db.Categories.FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception("Category not found");

            return category;
        }

        async Task<Category> ICategoryService.UpdateCategory(int id, Category category)
        {
            Category? dbCategory = await _db.Categories.FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception("Category not found");

            if (string.IsNullOrEmpty(category.Name))
            {
                throw new Exception("Category name is required");
            }

            dbCategory.Name = category.Name;
            await _db.SaveChangesAsync();
            return dbCategory;
        }
    }
}
