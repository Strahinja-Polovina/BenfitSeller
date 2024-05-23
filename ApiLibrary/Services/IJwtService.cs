using BaseLibrary.DTO;

namespace ApiLibrary.Services
{
    public interface IJwtService
    {
        public string GenerateToken(OCompanyDTO user);
        public OCompanyDTO? GetComapnyFromToken(string token);
        public string GenerateRefreshToken();
    }
}
