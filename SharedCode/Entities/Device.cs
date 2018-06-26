using System;

namespace IotCentral.Entities
{
    public class Device : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DeviceType Type { get; set; }

    }
}