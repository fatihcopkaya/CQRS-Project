using StajProjesiAPI.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.Abstract.Services
{
    public interface JWTTokenService
    {
        TokenVM GetToken(string email, string role);
        string CreateRefreshToken();


    }
        
        
}
