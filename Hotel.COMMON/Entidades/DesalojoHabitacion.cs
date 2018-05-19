using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Hotel.COMMON.Entidades
{
    public class DesalojoHabitacion:Base
    {
        public DateTime FechaFinal { get; set; }
        public string Nombre { get; set; }
    }
}
