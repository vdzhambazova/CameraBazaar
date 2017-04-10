using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CameraBazaar.Models.Models
{
    public class Role :IdentityRole
    {
        public Role()
        {
            
        }

        public Role(string name)
            :base(name)
        {
            
        }
    }
}
