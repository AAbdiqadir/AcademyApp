using Bckend.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bckend.Controllers;


public class usersController(AppDataContext db): baseAPiController
{
    // [HttpGet("{ID}")]
    // public ActionResult <IEnumerable<Appuser>> GetUsers(int id)
    // {
    //     var users = db.Appusers.ToList();
    //
    //     return users.ToList();
    // }
    
    [HttpGet]
    
    public async Task<ActionResult <IEnumerable<Appuser>>> GetUser()
    {
        var users = await db.Appusers.ToListAsync();

        return users.ToList();
    }
}
