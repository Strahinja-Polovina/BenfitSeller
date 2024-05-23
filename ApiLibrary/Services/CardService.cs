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
    public class CardService(ApplicationDbContext db) : ICardService
    {
        private readonly ApplicationDbContext _db = db;
        async Task<string> ICardService.AddFunds(int companyId, decimal amount, int EmployeId)
        {
            Company? company = await _db.Companies.FirstOrDefaultAsync(c => c.Id == companyId) ?? throw new Exception("Company not found");
            Employee? dbEmploye = await _db.Employees.FirstOrDefaultAsync(c => c.Id == EmployeId && c.CompanyId == companyId) ?? throw new Exception("Employee not found");
            Card? card = await _db.Cards.FirstOrDefaultAsync(c => c.EmployeeId == dbEmploye.Id) ?? throw new Exception("Card not found");

            card.Balance += amount;
            _db.Cards.Update(card);
            await _db.SaveChangesAsync();

            return $"Funds added successfully. New balance is {card.Balance}";
        }

        async Task<Card> ICardService.CreateCard(int companyId, Card card)
        {
            Employee dbEmployee = await _db.Employees.Include(e => e.Company).FirstOrDefaultAsync(e => e.Id == card.EmployeeId) ?? throw new Exception("Employee not found");
            Card? dbCard = await _db.Cards.FirstOrDefaultAsync(c => c.EmployeeId == card.EmployeeId || c.CardNumber == card.CardNumber);
            if (dbCard is not null) throw new Exception("Card already exists");
            
    
            if ( dbEmployee.CompanyId != companyId)
            {
                throw new Exception("Employee not found in company");
            }

            card.Pin = BCrypt.Net.BCrypt.HashPassword(card.Pin);

            await _db.Cards.AddAsync(card);
            await _db.SaveChangesAsync();

            return card;

        }

        async Task<string> ICardService.DeleteCard(int companyId, int CardId)
        {
            Company? company = await _db.Companies.FirstOrDefaultAsync(c => c.Id == companyId) ?? throw new Exception("Company not found");

            Card? card = await _db.Cards.FirstOrDefaultAsync(c => c.Id == CardId && c.Employee!.CompanyId == companyId) ?? throw new Exception("Card not found");

            _db.Cards.Remove(card);
            await _db.SaveChangesAsync();

            return $"Card with id {CardId} deleted successfully";
        }
    }
}
