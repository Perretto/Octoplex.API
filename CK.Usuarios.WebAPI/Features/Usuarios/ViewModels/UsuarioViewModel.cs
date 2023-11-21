using System.ComponentModel.DataAnnotations.Schema;

namespace Octoplex.Usuarios.WebAPI.Features.Usuarios.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public int ExpiredToken { get; set; }
    }
}
