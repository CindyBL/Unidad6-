using System;
using System.Collections.Generic;
using System.Text;
using Hotel.COMMON.Entidades;
using Hotel.COMMON.Interfaces;
using System.Linq;
using MongoDB.Bson;

namespace Hotel.BIZ
{
    public class ManejadorOtrosServicios : IManejadorOtroServicio
    {
        IRepositorio<OtrosServicios> repositorio;

        public ManejadorOtrosServicios(IRepositorio<OtrosServicios> repo)
        {
            repositorio = repo;
        }

        public List<OtrosServicios> Listar => repositorio.Read;

        public bool Agregar(OtrosServicios entidad)
        {
            return repositorio.Create(entidad);
        }

        public OtrosServicios BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(OtrosServicios entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
