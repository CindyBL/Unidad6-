using System;
using System.Collections.Generic;
using System.Text;
using Hotel.COMMON.Entidades;
using Hotel.COMMON.Interfaces;
using System.Linq;
using MongoDB.Bson;

namespace Hotel.BIZ
{
    public class ManejadorDesalojoH : IManejadorDesalojo
    {
        IRepositorio<DesalojoHabitacion> repositorio;

        public ManejadorDesalojoH(IRepositorio<DesalojoHabitacion> repo)
        {
            repositorio = repo;
        }

        public List<DesalojoHabitacion> Listar => repositorio.Read;

        public bool Agregar(DesalojoHabitacion entidad)
        {
            return repositorio.Create(entidad);
        }

        public DesalojoHabitacion BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(DesalojoHabitacion entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
