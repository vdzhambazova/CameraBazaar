using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraBazaar.Models.BindingModels
{
    public class EditUserViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string CurrentPassword { get; set; }
    }
}
