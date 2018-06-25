﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTCentral.Data
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<User> Users { get; set; }
        public Organization()
        {
            Users = new List<User>();
        }

    }

}
