using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IotCentral.Data
{
    public class OwnedModel
    {
        public int Id { get; set; }
        public Guid OwnerAccount { get; set; }
        public DateTime CreatedTimeStamp { get; set; } =  DateTime.UtcNow;
        
    }
}
