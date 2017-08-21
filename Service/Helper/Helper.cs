using Castle.Windsor;
using Service.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper
{
    class Helper
    {
       public static IWindsorContainer _container;
       public static  DataBaseContext db = new DataBaseContext();
    }
}
