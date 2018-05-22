using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.COMMON.Entidades
{
    public class ContraseñaCliente:Base
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string CContraseña { get; set; }
        public override string ToString()
        {
            return Usuario;
        }
    }
}
