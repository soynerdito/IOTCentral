using IotCentral.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace IotCentral.Storage
{
    public class GenericStorage<T> : IStorage<T> where T : IEntity
    {
        private HashSet<T> _Storage;

        public GenericStorage()
        {
            _Storage = new HashSet<T>();
        }

        public T Add(T device)
        {
            //Remove if exists
            _Storage.RemoveWhere(x => x.Id == device.Id);
            //Adds new one
            if(device.Id == new Guid())
            {
                device.Id = Guid.NewGuid();
            }
            
            _Storage.Add(device);
            return device;
        }

        public List<T> Get(Guid? id)
        {
            return _Storage.Where(x => x.Id == (id is null ? x.Id : id)).ToList();
        }
    }
}
