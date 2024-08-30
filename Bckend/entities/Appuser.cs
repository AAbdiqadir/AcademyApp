namespace Bckend.entities;

public class Appuser
{
    public int Id { get; set; }
    public required string LastName { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public required byte[] PasswordHash { get; set; }
    
}