using ClientManagerApi.Dtos.Auth;
using ClientManagerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagerApi.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<string?> LoginAsync(LoginRequest request);
    }
}
