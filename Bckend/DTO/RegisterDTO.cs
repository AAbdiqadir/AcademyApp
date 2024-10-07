using System.ComponentModel.DataAnnotations;

namespace Bckend.DTO;

public class RegisterDTO
{
    [Required]
    public  String username { get; set; }
    
    [Required]
    public String password { get; set; }
}