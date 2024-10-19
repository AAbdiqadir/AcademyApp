using Bckend.Extensions;

namespace Bckend.entities;

public class Appuser
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public byte[] PasswordSalt { get; set; } = [];
    public byte[] PasswordHash { get; set; } = [];
    
    public required string KnownAs { get; set; }
    
    public DateOnly Birthday { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public required string Gender { get; set; }
    
    public string ? introduction { get; set; }
    public string ? interests { get; set; }

    public List<Photo> Photos { get; set; } = [];

    public int getAge()
    {
        return Birthday.CalculateAge();
    }
    
}