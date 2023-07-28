using Microsoft.IdentityModel.Tokens;
using StajProjesiAPI.Application.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;



namespace StajProjesiAPI.Infrastructure.Security.JWT
{
    public class JWTToken
    {
        public static TokenVM GetToken(string email,string role)
        {
            var authClaims = new List<Claim> 
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            
            
            };
            TokenVM tokenVM = new TokenVM();
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3KBsVR697nrsqxfvvjlZDw=="));
            var token = new JwtSecurityToken
            (
                   issuer:"https://localhost:7272/",
                   audience: "https://localhost:7272/",
                   expires: DateTime.Now.AddHours(24),
                   claims: authClaims,
                   signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            tokenVM.AccessToken = tokenHandler.WriteToken(token);
            tokenVM.Expiration = DateTime.Now.AddHours(24);

            tokenVM.RefreshToken = CreateRefreshToken();
            tokenVM.Expiration = DateTime.Now.AddDays(7);
            return tokenVM;

            

        }
        public static string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }


    }
}
