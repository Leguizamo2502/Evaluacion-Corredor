﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Domain.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool isDeleted { get; set; }

    }
}
