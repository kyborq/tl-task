﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebAPI
{
    public class TodoDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }
}
