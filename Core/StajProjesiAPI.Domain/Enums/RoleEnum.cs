using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajProjesiAPI.Domain.Enums
{
    public enum RoleEnum
    {
        [Description("Admin")]
        Admin,
        [Description("User")]
        User,
        
    }
}
