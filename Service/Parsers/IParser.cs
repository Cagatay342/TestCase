﻿using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Parsers
{
    interface IParser
    {
        List<Haber> Parse();


    }
}
