using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
