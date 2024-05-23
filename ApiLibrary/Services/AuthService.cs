using ApiLibrary.Data;
using ApiLibrary.Models;
using AutoMapper;
using BaseLibrary.DTO;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;


namespace ApiLibrary.Services
{
    public class AuthService(ApplicationDbContext db, IJwtService jwt, IMapper mapper) : IAuthService
    {
        private readonly ApplicationDbContext _db = db;
        private readonly IJwtService _jwt = jwt;
        private readonly IMapper _mapper = mapper;
        async Task<LoginResponse> IAuthService.Login(LoginDTO login)
        {
            if (string.IsNullOrEmpty(login.Email)) throw new Exception("Email is required");
            if (string.IsNullOrEmpty(login.Password)) throw new Exception("Password is required");

            var comapny = await _db.Companies.FirstOrDefaultAsync(c => c.Email == login.Email) ?? throw new Exception("Company not found");
            if (!BCrypt.Net.BCrypt.Verify(login.Password, comapny.Password)) throw new Exception("Invalid password");

            string refreshToken = _jwt.GenerateRefreshToken();

            comapny.RefreshToken = refreshToken;
            await _db.SaveChangesAsync();

            OCompanyDTO companyDto = _mapper.Map<OCompanyDTO>(comapny);

            string token = _jwt.GenerateToken(companyDto);

            RefreshTokenDTO refreshTokenDTO = new() { Token = comapny.RefreshToken };

            LoginResponse loginResponse = new() { Token = token, User = companyDto, RefreshToken = refreshTokenDTO.Token };

            return loginResponse;
        }

        public async Task<LoginResponse> Refresh(RefreshTokenDTO refreshToken)
        {
            Company? user = await _db.Companies.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken.Token) ?? throw new Exception("Invalid refresh token");
            string newRefreshToken = _jwt.GenerateRefreshToken();

            OCompanyDTO userDTO = _mapper.Map<OCompanyDTO>(user);

            string token = _jwt.GenerateToken(userDTO);

            user.RefreshToken = newRefreshToken;
            await _db.SaveChangesAsync();

            RefreshTokenDTO refreshTokenDTO = new() { Token = user.RefreshToken };

            return new LoginResponse { Token = token, User = userDTO, RefreshToken = refreshTokenDTO.Token };
        }

    }
}
