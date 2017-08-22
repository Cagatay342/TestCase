using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Service.Models;

namespace Service.Publishers
{
    class MilliyetTech : IPublisher
    {
        public Haber getHaber(XmlNode childrenNode)
        {
            return new Haber
            {
                title = childrenNode["title"].InnerText,
                description = childrenNode["description"].InnerText,
                guid = childrenNode["guid"].InnerText,
                link = childrenNode["link"].InnerText,
                pubdate = DateTime.Parse(childrenNode["pubDate"].InnerText)
            };
        }

        public string getUri()
        {
            return "http://www.milliyet.com.tr/rss/rssNew/teknolojiRss.xml";
        }

        public string getXpath()
        {
            return "rss/channel/item";
        }
    }
}
