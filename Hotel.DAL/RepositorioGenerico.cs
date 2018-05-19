﻿using System;
using System.Collections.Generic;
using System.Text;
using Hotel.COMMON.Interfaces;
using Hotel.COMMON.Entidades;
using MongoDB.Driver;
using System.Linq;
using MongoDB.Bson;

namespace Hotel.DAL
{
    public class RepositorioGenerico<T> : IRepositorio<T> where T : Base
    {
        private MongoClient client;
        private IMongoDatabase db;

        public RepositorioGenerico()
        {
            client = new MongoClient(new MongoUrl("mongodb://HotelU6:12345@ds121950.mlab.com:21950/hotel"));
            db = client.GetDatabase("hotel");
        }

        private IMongoCollection<T> Collection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }

        public List<T> Read => Collection().AsQueryable().ToList();

        public bool Create(T entidad)
        {
            try
            {
                Collection().InsertOne(entidad);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(ObjectId id)
        {
            try
            {
                return Collection().DeleteOne(p => p.Id == id).DeletedCount == 1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(T entidadModificada)
        {
            try
            {
                return Collection().ReplaceOne(p => p.Id == entidadModificada.Id, entidadModificada).ModifiedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
