using System.ComponentModel.DataAnnotations;

namespace Bckend.DTO;

public class loginDTO
{
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}