using HBS.HairBySilke_2021.Security.Models;

namespace HBS.HairBySilke_2021.Security.IServices
{
    public interface IAuthUserService
    {
        AuthUser Login(string username, string password);
        
    }
}