using System.ComponentModel.DataAnnotations;

namespace Bckend.DTO;

public class RegisterDTO
{
    [Required] 
    public  String Username { get; set; }
    
    [Required] 
    [StringLength(8, MinimumLength = 5)]
    public String Password { get; set; }
}