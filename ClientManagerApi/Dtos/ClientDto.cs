using System.ComponentModel.DataAnnotations;

namespace ClientManagerApi.Dtos
{
    public class ClientDto
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(15)]
        public string Email { get; set; } = string.Empty;
    }
}
