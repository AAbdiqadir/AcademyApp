using System.ComponentModel.DataAnnotations;

namespace Bckend.DTO;

public class UserDTO
{
    public required string Username { get; set; }
    
    public required string Token { get; set; }
}