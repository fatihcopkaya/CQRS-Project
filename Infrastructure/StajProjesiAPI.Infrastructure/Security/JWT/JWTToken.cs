using Microsoft.IdentityModel.Tokens;
using StajProjesiAPI.Application.Abstract.Services;
using StajProjesiAPI.Application.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;



namespace StajProjesiAPI.Infrastructure.Security.JWT
{
    public class JWTToken : JWTTokenService
    {
        public  TokenVM GetToken(string email,string role)
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
                   expires: DateTime.UtcNow.AddDays(1),
                   claims: authClaims,
                   signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            tokenVM.AccessToken = tokenHandler.WriteToken(token);
            tokenVM.Expiration = DateTime.UtcNow.AddDays(1);

            tokenVM.RefreshToken = CreateRefreshToken();
            tokenVM.RefreshTokenEndDate = DateTime.Now.AddDays(7);
            return tokenVM;

            

        }
        public  string CreateRefreshToken()
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
