using System;
using System.Collections.Generic;
using System.Text;
using Hotel.COMMON.Entidades;
using Hotel.COMMON.Interfaces;
using System.Linq;
using MongoDB.Bson;

namespace Hotel.BIZ
{
    public class ManejadorContraseñaClientes : IManejadorContraseñaCliente
    {

        IRepositorio<ContraseñaCliente> repositorio;

        public ManejadorContraseñaClientes(IRepositorio<ContraseñaCliente> repo)
        {
            repositorio = repo;
        }

        public List<ContraseñaCliente> Listar => repositorio.Read;

        public bool Agregar(ContraseñaCliente entidad)
        {
            return repositorio.Create(entidad);
        }

        public ContraseñaCliente BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(ContraseñaCliente entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
