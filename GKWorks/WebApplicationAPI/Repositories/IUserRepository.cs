using WebApplicationAPI.Models.Domain;

namespace WebApplicationAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateUser(string username, string password);

    }
}
