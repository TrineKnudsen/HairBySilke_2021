using HBS.HairBySilke_2021.Security.models;

namespace HBS.HairBySilke_2021.Security.IServices
{
    public interface ISecurityService
    {
        JwtToken GenerateJwtToken(string username, string password);
    }
}