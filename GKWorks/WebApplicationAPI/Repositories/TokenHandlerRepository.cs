using WebApplicationAPI.Models.Domain;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace WebApplicationAPI.Repositories
{
    public class TokenHandlerRepository : ITokenHandler
    {
       private readonly IConfiguration configuration;
        public TokenHandlerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        public Task<string> CreateTokenAsync(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            claims.Add(new Claim(ClaimTypes.Email, user.EmailAddress));

            user.Role.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires : DateTime.Now.AddMinutes(10),
                signingCredentials : credentials);
            return Task.FromResult( new JwtSecurityTokenHandler().WriteToken(token));
            //throw new NotImplementedException();
        }
    }
}
