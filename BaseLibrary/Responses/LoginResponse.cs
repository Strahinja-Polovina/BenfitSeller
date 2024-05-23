﻿using BaseLibrary.DTO;

namespace BaseLibrary.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public OCompanyDTO? User { get; set; }
    }
}
