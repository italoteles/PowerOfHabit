namespace PowerOfHabit.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string userName, string password);
        
        Task Logout();
    }
}
