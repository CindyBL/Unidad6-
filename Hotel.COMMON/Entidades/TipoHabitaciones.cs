using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.COMMON.Entidades
{
    public class TipoHabitaciones:Base
    {
        public string NombtreTipoH { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", NombtreTipoH);
        }
    }

}
