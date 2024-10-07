using System.Security.Cryptography;
using System.Text;
using Bckend.DTO;
using Bckend.entities;
using Bckend.Interface;
using Bckend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bckend.Controllers;


public class accountController(AppDataContext _dB,ITokenService tokenService):baseAPiController
{

    [HttpPost("Register")]
    public  async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
    {

        if (await userExists(registerDto.username) )
        {
            return BadRequest("Username already exists");
        }
        using var hmac = new HMACSHA512();

        var user = new Appuser
        {
            LastName = registerDto.username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password)),
            PasswordSalt = hmac.Key
        };
        
        _dB.Appusers.Add(user);
        await _dB.SaveChangesAsync();

        return new UserDTO
        {
            Username = user.LastName,
            Token = tokenService.CreateToken(user)
        } 
            ;
    }

    [HttpPost("Login")]

    public async Task<ActionResult<UserDTO>> Login(loginDTO loginDto)
    {
        var user = await _dB.Appusers.FirstOrDefaultAsync(x =>  x.LastName.ToLower() == loginDto.Username.ToLower());

        using var hmac = new HMACSHA512(user.PasswordSalt);
        
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
        
        if (user == null) { return Unauthorized("Invalid username"); }

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (user.PasswordHash[i] != computedHash[i])
            {
                return Unauthorized("Invalid password");
            }
            
        }
        return new UserDTO
        {
            Username = user.LastName,
            Token = tokenService.CreateToken(user)
        } ;


    }

    
    private async Task<bool> userExists(String  userNama)
    {
        return await _dB.Appusers.AnyAsync(x => x.LastName.ToLower() == userNama.ToLower());
    }
    
    
}