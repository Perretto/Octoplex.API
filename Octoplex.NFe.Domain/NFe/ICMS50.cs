﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octoplex.NFe.Domain.NFe
{
    // Grupo N06. Grupo Tributação do ICMS= 40, 41, 50
    public class ICMS50
    {
        public int orig { get; set; }
        public decimal vICMSDeson { get; set; }
        public int motDesICMS { get; set; }
    }
}