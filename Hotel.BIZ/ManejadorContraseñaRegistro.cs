using System;
using System.Collections.Generic;
using System.Text;
using Hotel.COMMON.Entidades;
using Hotel.COMMON.Interfaces;
using System.Linq;
using MongoDB.Bson;

namespace Hotel.BIZ
{
    public class ManejadorContraseñaRegistro : IManejadorContraseñaRegistro
    {
        IRepositorio<ContraseñaRegistro> repositorio;

        public ManejadorContraseñaRegistro(IRepositorio<ContraseñaRegistro> repo)
        {
            repositorio = repo;
        }

        public List<ContraseñaRegistro> Listar => repositorio.Read;

        public bool Agregar(ContraseñaRegistro entidad)
        {
            return repositorio.Create(entidad);
        }

        public ContraseñaRegistro BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(ContraseñaRegistro entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
