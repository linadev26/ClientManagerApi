using ClientManagerApi.Dtos;
using ClientManagerApi.Models;
using ClientManagerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClientManagerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {

        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetClients()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                return Unauthorized();

            var clients = await _clientService.GetClientsAsync(userId);
            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientDto clientDto)
        {
            try
            {
                var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                    return Unauthorized();

                var created = _clientService.CreateClientAsync(clientDto, userId);
                return Ok(created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetClientById(int clienteId)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                return Unauthorized();

            var client = _clientService.GetClientByIdAsync(clienteId, userId);

            if(client == null)
                return NotFound();

            return Ok(client);
        }
    }
}
