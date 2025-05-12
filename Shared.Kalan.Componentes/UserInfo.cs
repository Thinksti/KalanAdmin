using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Kalan.Componentes
{
    public class UserInfo
    {
 
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string connectionString { get; set; } 
        public string Login { get; set; }

        public string Nombre { get; set; } 
         
    }
}
