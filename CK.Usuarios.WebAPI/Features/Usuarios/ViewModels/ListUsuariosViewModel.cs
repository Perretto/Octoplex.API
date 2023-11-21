using Octoplex.Usuarios.Domain.Usuarios;
using System.Collections.Generic;

namespace Octoplex.Usuarios.WebAPI.Features.Usuarios.ViewModels
{
    public class ListUsuariosViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
