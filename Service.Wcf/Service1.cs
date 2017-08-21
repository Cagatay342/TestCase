﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Service.Models;
using Service.Bussines;

namespace Service.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        IHaberYonet _db = Helper.Helper._container.Resolve<IHaberYonet>();

        List<Haber> IService1.GetData()
        {

            return _db.Goster();
        }
    }
}
