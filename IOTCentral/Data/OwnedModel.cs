﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTCentral.Data
{
    public class OwnedModel
    {
        public int Id { get; set; }
        public Guid OwnerAccount { get; set; }
    }
}
