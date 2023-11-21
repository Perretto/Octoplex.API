using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.Usuarios.Domain.Usuarios
{
    public class Usuario
    {
        //public Usuario(string username, string password, string role)
        //{
        //    Username = username;
        //    Password = password;
        //    Role = role;
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [NotMapped]
        public string Token { get; set; }
        [NotMapped]
        public int ExpiredToken { get; set; }
    }
}
