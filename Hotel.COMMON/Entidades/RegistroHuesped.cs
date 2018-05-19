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
    }
}
