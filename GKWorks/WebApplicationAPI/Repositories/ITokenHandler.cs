namespace WebApplicationAPI.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(Models.Domain.User user);
    }
}
