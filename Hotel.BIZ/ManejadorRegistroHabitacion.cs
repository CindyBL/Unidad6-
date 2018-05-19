using System;
using System.Collections.Generic;
using System.Text;
using Hotel.COMMON.Entidades;
using Hotel.COMMON.Interfaces;
using System.Linq;
using MongoDB.Bson;

namespace Hotel.BIZ
{
    public class ManejadorRegistroHabitacion : IManejadorRegistroHabitacion
    {
        IRepositorio<RegistroHabitacion> repositorio;

        public ManejadorRegistroHabitacion(IRepositorio<RegistroHabitacion> repo)
        {
            repositorio = repo;
        }

        public List<RegistroHabitacion> Listar => repositorio.Read;

        public bool Agregar(RegistroHabitacion entidad)
        {
            return repositorio.Create(entidad);
        }

        public RegistroHabitacion BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(RegistroHabitacion entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
