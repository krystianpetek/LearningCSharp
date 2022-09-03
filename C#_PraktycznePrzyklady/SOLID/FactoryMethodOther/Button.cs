﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodOther
{
    public abstract class Button
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract void Action();
    }
}
