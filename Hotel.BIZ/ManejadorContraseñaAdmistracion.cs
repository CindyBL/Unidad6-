using System;
using System.Collections.Generic;
using System.Text;
using Hotel.COMMON.Entidades;
using Hotel.COMMON.Interfaces;
using System.Linq;
using MongoDB.Bson;

namespace Hotel.BIZ
{
    public class ManejadorContraseñaAdmistracion : IManejadorContraseñaAdministrar
    {

        IRepositorio<ContraseñaAdministrador> repositorio;

        public ManejadorContraseñaAdmistracion(IRepositorio<ContraseñaAdministrador> repo)
        {
            repositorio = repo;
        }

        public List<ContraseñaAdministrador> Listar => repositorio.Read;

        public bool Agregar(ContraseñaAdministrador entidad)
        {
            return repositorio.Create(entidad);
        }

        public ContraseñaAdministrador BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(ContraseñaAdministrador entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
