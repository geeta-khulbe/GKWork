using WebApplicationAPI.Models.Domain;

namespace WebApplicationAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        List<User> users = new List<User>()
        {
            new User()
            {
                Username = "readOnly",Password = "P@ssw0rd",
                FirstName = "Geeta",User_Id = new Guid()
                ,LastName = "khulbe",EmailAddress = "@gmail.com",
                Role = new List<string>{"reader"}
            },
            new User()
            {
                 Username = "readWrite",Password = "P@ssw0rd",
                FirstName = "Geeta",User_Id = new Guid()
                ,LastName = "khulbe",EmailAddress = "@gmail.com",
                Role = new List<string>{"reader","writer"}
            }

        };

        public async Task<bool>Authenticate(string username, string password)
        {
            var result = users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
                x.Password == password);
            if (result != null)
                return true;
            else
                return false;
        }

        public async Task<User>AuthenticateUser(string username, string password)
        {
            var user = users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
                 x.Password == password);
            return user;
        }
    }
}
