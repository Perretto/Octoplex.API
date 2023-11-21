using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Domain.Usuarios
{
    public class UsuarioDTO
    {
        List<Usuario> Usuarios { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
