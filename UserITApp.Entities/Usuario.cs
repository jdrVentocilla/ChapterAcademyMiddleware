using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserITApp.Entities
{
    public class Usuario
    {
        
        public string Id { get; set; }
        public string Nombre { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Usuario(string id, string nombre, string login, string password, string email)
        {
            Id = id;
            Nombre = nombre;
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
