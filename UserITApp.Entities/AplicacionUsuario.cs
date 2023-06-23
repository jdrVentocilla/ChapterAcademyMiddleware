using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserITApp.Entities
{
    public class AplicacionUsuario
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public Aplicacion Aplicacion { get; set; }

        public AplicacionUsuario()
        {
           
        }
    }
}
