using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Service.Publishers
{
    interface IPublisher
    {
        string getUri();
        string getXpath();
        Haber getHaber(XmlNode childrenNode);

    }
}
