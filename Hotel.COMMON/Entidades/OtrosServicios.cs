using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.COMMON.Entidades
{
    public class OtrosServicios:Base
    {
        public string NombreServicio { get; set; }
        public string Descripcion { get; set; }
        public byte[] FotografiaServicio { get; set; }
    }
}
