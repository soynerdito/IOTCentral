using System;
using System.Collections.Generic;

namespace IotCentral.Storage
{
    public interface IStorage<T>
    {
        T Add(T device);
        List<T> Get(Guid? id);
    }
}