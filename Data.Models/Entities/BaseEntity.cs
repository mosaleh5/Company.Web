﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
