﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Class1
    {
        protected Class1()
        {
        }

        protected Class1(string nombre)
        {
            this.nombre = nombre;
        }

        public string nombre { get; set; }


    }
}
