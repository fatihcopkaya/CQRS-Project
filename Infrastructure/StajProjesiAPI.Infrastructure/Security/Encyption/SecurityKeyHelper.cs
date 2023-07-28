using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace StajProjesiAPI.Infrastructure.Security.Encyption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string security)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(security));
        }
    }
}
