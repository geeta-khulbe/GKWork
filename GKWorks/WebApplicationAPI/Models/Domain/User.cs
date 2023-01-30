namespace WebApplicationAPI.Models.Domain
{
    public class User
    {
        public Guid User_Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public List<string> Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
