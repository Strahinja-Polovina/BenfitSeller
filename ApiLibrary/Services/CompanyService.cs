using ApiLibrary.Data;
using ApiLibrary.Helpers;
using ApiLibrary.Models;
using AutoMapper;
using BaseLibrary.DTO;
using Microsoft.EntityFrameworkCore;


namespace ApiLibrary.Services
{
    public class CompanyService(ApplicationDbContext db, IMapper mapper) : ICompanyService
    {
        private readonly ApplicationDbContext _db = db;
        private readonly IMapper _mapper = mapper;
        async Task<OCompanyDTO> ICompanyService.CreateCompany(AddCompanyDTO company)
        {
            Company? companyDb = await _db.Companies.FirstOrDefaultAsync(c => c.Email == company.Email);
            if (companyDb is not null)
            {
                if (companyDb.IsDeleted)
                {

                    if (!string.IsNullOrEmpty(company.Name))
                    {
                        companyDb.Name = company.Name;

                    }

                    if (!string.IsNullOrEmpty(company.Password))
                    {
                        companyDb.Password = BCrypt.Net.BCrypt.HashPassword(company.Password);

                    }
                    companyDb.IsDeleted = false;
                    companyDb.DeletedAt = null;
                    companyDb.UpdatedAt = DateTime.Now;
                    await _db.SaveChangesAsync();
                    _mapper.Map(company, companyDb);

                    var companyDto = _mapper.Map<OCompanyDTO>(companyDb);
                    return companyDto;
                }
                else
                {
                    throw new Exception("Comapny already exists");
                }
            }
            else
            {
                var newComapny = _mapper.Map<Company>(company);
                newComapny.Password = BCrypt.Net.BCrypt.HashPassword(company.Password);
                newComapny.CreatedAt = DateTime.Now;
                await _db.Companies.AddAsync(newComapny);
                await _db.SaveChangesAsync();

                var userDto = _mapper.Map<OCompanyDTO>(newComapny);

                return userDto;
            }

        }

        async Task<string> ICompanyService.DeleteCompany(int id)
        {
            Company? comapny = await _db.Companies.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception("Company not found");
            if (comapny.IsDeleted)
            {
                throw new Exception("Comapny not found.");
            }

            if (comapny.Role == Constants.AdminRole)
            {
                throw new Exception("You can't delete admin");
            }
            else
            {
                comapny.IsDeleted = true;
                comapny.DeletedAt = DateTime.Now;
                await _db.SaveChangesAsync();
                return $"Company with id: {id} - deleted";
            }

        }

        async Task<List<OCompanyDTO>> ICompanyService.GetAllCompanies()
        {
            List<Company> companies = await _db.Companies.Where(c => !c.IsDeleted).Where(c => c.Role != Constants.AdminRole).ToListAsync();
            if (companies.Count == 0)
            {
                throw new Exception("No companies found");
            }

            return companies.Select(_mapper.Map<OCompanyDTO>).ToList();
        }

        async Task<OCompanyDTO> ICompanyService.GetCompanyById(int id)
        {
            Company? user = _db.Companies.Where(c => c.Id == id).Where(u => !u.IsDeleted).FirstOrDefault();
            return user is null ? throw new Exception("Company not found") : await Task.FromResult(_mapper.Map<OCompanyDTO>(user));
        }

        async Task<OCompanyDTO> ICompanyService.UpdateCompany(int id, IUpdateCompanyDTO companyDTO)
        {
            Company? company = _db.Companies.Where(c => c.Id == id).Where(c => !c.IsDeleted).FirstOrDefault() ?? throw new Exception("Comapny not found");
            if (!string.IsNullOrEmpty(companyDTO.Name))
            {
                company.Name = companyDTO.Name;
                company.UpdatedAt = DateTime.Now;
            }

            if (!string.IsNullOrEmpty(companyDTO.Email))
            {
                company.Email = companyDTO.Email;
                company.UpdatedAt = DateTime.Now;
            }

            if (!string.IsNullOrEmpty(companyDTO.Password))
            {
                company.Password = BCrypt.Net.BCrypt.HashPassword(companyDTO.Password);
                company.UpdatedAt = DateTime.Now;
            }

            if (!string.IsNullOrEmpty(companyDTO.Role))
            {
                company.Role = companyDTO.Role;
                company.UpdatedAt = DateTime.Now;
            }

            _db.SaveChanges();

            return await Task.FromResult(_mapper.Map<OCompanyDTO>(company));

        }
    }
}
