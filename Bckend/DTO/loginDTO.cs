using System.ComponentModel.DataAnnotations;

namespace Bckend.DTO;

public class loginDTO
{
    [Required]
    public  String Username { get; set; }
    
    [Required]
    public String Password { get; set; }
}
