using BaseLibrary.DTO;

namespace ApiLibrary.Services
{
    public interface ICompanyService
    {
        public Task<OCompanyDTO> CreateCompany(AddCompanyDTO user);
        public Task<OCompanyDTO> UpdateCompany(int id, IUpdateCompanyDTO user);
        public Task<OCompanyDTO> GetCompanyById(int id);
        public Task<List<OCompanyDTO>> GetAllCompanies();
        public Task<string> DeleteCompany(int id);
    }
}
