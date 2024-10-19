using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Bckend.entities;
using Microsoft.EntityFrameworkCore;

namespace Bckend.Data;

public class Seed
{
    public static async Task SeedUsers(AppDataContext db)
    {
        if (await db.Appusers.AnyAsync()) return;
        
        var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        
        var users = JsonSerializer.Deserialize<List<Appuser>>(userData, options);


        if (users == null) return; 
        foreach (var user in users)
        {
            using var hmac = new HMACSHA512();

            user.UserName = user.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Ahmedow"));
            user.PasswordSalt = hmac.Key;
            
            db.Appusers.Add(user);

        }
        await db.SaveChangesAsync();
        
    }
}