using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Application.ViewModel
{
    public class TokenVM
    {
        
            public string AccessToken { get; set; }
            public DateTime Expiration { get; set; }
            public string RefreshToken { get; set; }
            public DateTime RefreshTokenEndDate { get; set; }

        
    }
}
