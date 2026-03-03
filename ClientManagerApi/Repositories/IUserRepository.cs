using ClientManagerApi.Dtos.Auth;
using ClientManagerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagerApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
