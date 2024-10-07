using System.Security.Cryptography;
using System.Text;
using Bckend.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bckend.Controllers;


public class accountController(AppDataContext _dB):baseAPiController
{

    [HttpPost("Register")]
    public  async Task<ActionResult<Appuser>> Register(String username, String password)
    {

        if (await userExists(username) )
        {
            return BadRequest("Username already exists");
        }
        using var hmac = new HMACSHA512();

        var user = new Appuser
        {
            LastName = username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
        };
        
        _dB.Appusers.Add(user);
        await _dB.SaveChangesAsync();

        return user;
    }

    [HttpPost("Login")]

    public async Task<ActionResult<Appuser>> Login(String username, String password)
    {
        var user = await _dB.Appusers.FirstOrDefaultAsync(x =>  x.LastName.ToLower() == username.ToLower());

        using var hmac = new HMACSHA512(user.PasswordSalt);
        
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        
        if (user == null) { return Unauthorized("Invalid username"); }

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (user.PasswordHash[i] != computedHash[i])
            {
                return Unauthorized("Invalid password");
            }
            
        }

        return user;


    }

    
    private async Task<bool> userExists(String  userNama)
    {
        return await _dB.Appusers.AnyAsync(x => x.LastName.ToLower() == userNama.ToLower());
    }
    
    
}