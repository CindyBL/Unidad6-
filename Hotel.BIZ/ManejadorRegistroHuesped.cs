using System;
using System.Collections.Generic;
using System.Text;
using Hotel.COMMON.Entidades;
using Hotel.COMMON.Interfaces;
using System.Linq;
using MongoDB.Bson;

namespace Hotel.BIZ
{
    public class ManejadorRegistroHuesped : IManejadorRegistroHuesped
    {
        IRepositorio<RegistroHuesped> repositorio;

        public ManejadorRegistroHuesped(IRepositorio<RegistroHuesped> repo)
        {
            repositorio = repo;
        }

        public List<RegistroHuesped> Listar => repositorio.Read;

        public bool Agregar(RegistroHuesped entidad)
        {
            return repositorio.Create(entidad);
        }

        public RegistroHuesped BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(RegistroHuesped entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
