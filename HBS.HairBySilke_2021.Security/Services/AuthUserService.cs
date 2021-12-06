using HBS.HairBySilke_2021.Security.IRepositories;
using HBS.HairBySilke_2021.Security.IServices;
using HBS.HairBySilke_2021.Security.Models;

namespace HBS.HairBySilke_2021.Security.Services
{
    public class AuthUserService : IAuthUserService
    {
        private readonly IAuthUserRepository _authUserRepository;

        public AuthUserService(IAuthUserRepository authUserRepository)
        {
            _authUserRepository = authUserRepository;
        }

        public AuthUser GetUser(string username)
        {
            return _authUserRepository.FindUser(username);
        }
    }
}