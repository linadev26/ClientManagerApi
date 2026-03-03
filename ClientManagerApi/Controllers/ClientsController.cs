using ClientManagerApi.Dtos;
using ClientManagerApi.Models;
using ClientManagerApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return Ok(userId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientDto clientDto)
        {
            try
            {
                var created = _clientService.CreateClientAsync(clientDto);
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
            var client = _clientService.GetClientByIdAsync(clienteId);

            if(client == null)
                return NotFound();

            return Ok(client);
        }
    }
}
