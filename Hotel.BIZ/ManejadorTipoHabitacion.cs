using System;
using System.Collections.Generic;
using System.Text;
using Hotel.COMMON.Entidades;
using Hotel.COMMON.Interfaces;
using System.Linq;
using MongoDB.Bson;

namespace Hotel.BIZ
{
    public class ManejadorTipoHabitacion : IManejadorTipoHabitacion
    {
        IRepositorio<TipoHabitaciones> repositorio;

        public ManejadorTipoHabitacion(IRepositorio<TipoHabitaciones> repo)
        {
            repositorio = repo;
        }

        public List<TipoHabitaciones> Listar => repositorio.Read;

        public bool Agregar(TipoHabitaciones entidad)
        {
            return repositorio.Create(entidad);
        }

        public TipoHabitaciones BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(TipoHabitaciones entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
