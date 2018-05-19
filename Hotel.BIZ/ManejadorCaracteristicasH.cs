using System;
using System.Collections.Generic;
using System.Text;
using Hotel.COMMON.Entidades;
using Hotel.COMMON.Interfaces;
using System.Linq;
using MongoDB.Bson;

namespace Hotel.BIZ
{
    public class ManejadorCaracteristicasH : IManejadorCaracteristicas
    {
        IRepositorio<CaracteristicasHabitacion> repositorio;

        public ManejadorCaracteristicasH(IRepositorio<CaracteristicasHabitacion> repo)
        {
            repositorio = repo;
        }

        public List<CaracteristicasHabitacion> Listar => repositorio.Read;

        public bool Agregar(CaracteristicasHabitacion entidad)
        {
            return repositorio.Create(entidad);
        }

        public CaracteristicasHabitacion BuscarPorId(ObjectId id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(CaracteristicasHabitacion entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
