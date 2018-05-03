using System;
using System.Collections.Generic;

namespace IOTCentral.Storage
{
    public interface IStorage<T>
    {
        T Add(T device);
        List<T> Get(Guid? id);
    }
}