using System.Security.Cryptography;
using System.Text;
using Bckend.DTO;
using Bckend.entities;
using Bckend.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bckend.Controllers;

public class accountController(AppDataContext _dB, ITokenService tokenService) : baseAPiController
{

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
    {
        return Ok();
        // if (await userExists(registerDto.Username)) return BadRequest("Username already exists");
        // using var hmac = new HMACSHA512();
        //
        // var user = new Appuser
        // {
        //     LastName = registerDto.Username.ToLower(),
        //     PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        //     PasswordSalt = hmac.Key
        // };
        //
        // _dB.Appusers.Add(user);
        // await _dB.SaveChangesAsync();
        //
        // return new UserDTO
        //     {
        //         Username = user.LastName,
        //         Token = tokenService.CreateToken(user)
        //     }
        //     ;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserDTO>> Login(loginDTO loginDto)
    {
        var user = await _dB.Appusers.FirstOrDefaultAsync(x => x.UserName.ToLower() == loginDto.Username.ToLower());

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        if (user == null) return Unauthorized("Invalid username");

        for (var i = 0; i < computedHash.Length; i++)
            if (user.PasswordHash[i] != computedHash[i])
                return Unauthorized("Invalid password");
        return new UserDTO
        {
            Username = user.UserName,
            Token = tokenService.CreateToken(user)
        };
    }


    private async Task<bool> userExists(string userNama)
    {
        return await _dB.Appusers.AnyAsync(x => x.UserName
            .ToLower() == userNama.ToLower());
    }
}