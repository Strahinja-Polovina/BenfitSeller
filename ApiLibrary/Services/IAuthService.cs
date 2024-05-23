using BaseLibrary.DTO;
using BaseLibrary.Responses;

namespace ApiLibrary.Services
{
    public interface IAuthService
    {
        public Task<LoginResponse> Login(LoginDTO login);
        public Task<LoginResponse> Refresh(RefreshTokenDTO refreshToken);
    }
}
