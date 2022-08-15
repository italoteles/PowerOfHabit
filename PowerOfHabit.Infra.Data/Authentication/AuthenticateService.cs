using PowerOfHabit.Domain.Account;
using PowerOfHabit.Domain.Entities;
using PowerOfHabit.Domain.Interfaces;

namespace PowerOfHabit.Infra.Data.Authentication
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Authenticate(string userName, string password)
        {
            var user = await _userRepository.Authenticate(userName, password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
