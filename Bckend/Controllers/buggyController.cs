using Bckend.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bckend.Controllers;

public class buggyController(AppDataContext db) : baseAPiController
{
    
    [Authorize]

    [HttpGet("auth")]

    public ActionResult<string> GetAuth()
    {
        return "Secret test";
    }
    [HttpGet("not_found")]

    public ActionResult<Appuser> GetNotfound()
    {
        var user = db.Appusers.Find(-1);

        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpGet("server-error")]

    public ActionResult<Appuser>GetServerError()
    {
        var ret = db.Appusers.Find(-1)?? throw new Exception("A bad error occured");
        return ret;
    }

    [HttpGet("bad-request")]

    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("not found");
    }
    


    
    
    
}