using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.COMMON.Entidades
{
    public class ContraseñaRegistro:Base
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public override string ToString()
        {
            return Usuario;
        }
    }
}
