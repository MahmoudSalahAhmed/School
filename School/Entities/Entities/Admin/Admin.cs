﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Admin : BaseModel
    {
        public string Password { get; set; }
        public virtual User User { get; set; }
    }
}
