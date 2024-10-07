using Bckend.entities;

namespace Bckend.Interface;

public interface ITokenService
{
    string CreateToken(Appuser appuser);
    
}