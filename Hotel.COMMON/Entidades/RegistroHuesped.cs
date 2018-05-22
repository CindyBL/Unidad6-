using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Hotel.COMMON.Entidades
{
    public class RegistroHuesped:Base
    {
        public DateTime FechaInicial { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Habitacion { get; set; }
        public string DiasHospedaje { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", Nombre,Apellido);
        }
    }
}
