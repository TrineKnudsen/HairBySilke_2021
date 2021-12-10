using HBS.HairBySilke_2021.Security.Models;

namespace HBS.HairBySilke_2021.Security.IRepositories
{
    public interface IAuthUserRepository
    {
        AuthUser FindByUsernameAndPassword(string username, string password);
        AuthUser FindUser(string username);
    }
}