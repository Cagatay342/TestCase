using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Publishers;
using System.Net;
using System.Xml.Linq;
using System.Xml;
using Service.Bussines;
using Service.Models;

namespace Service.Parsers
{
    class Parser :IParser
    {
        IPublisher _pub=null;
        IHaberYonet _db = null;
        public  Parser()
        {
            _pub = Helper.Helper._container.Resolve<IPublisher>();
            _db = Helper.Helper._container.Resolve<IHaberYonet>();
        }

   

        string GetXml(string link)
        {
            string htmlCode = "";
            using (WebClient client = new WebClient())
            {
                 htmlCode = client.DownloadString(link);
            }
            return htmlCode;
        }

        public List<Haber> Parse()
        {
        
            string Xml = GetXml(_pub.getUri());

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(Xml);

            string xpath = "rss/channel/item";
            var nodes = xmlDoc.SelectNodes(xpath);

            List<Haber> haberler = new List<Haber>();


            foreach (XmlNode childrenNode in nodes)
            {
                haberler.Add(new Haber
                {
                    title = childrenNode["title"].InnerText,
                    description = childrenNode["description"].InnerText,
                    guid = childrenNode["guid"].InnerText,
                    link = childrenNode["link"].InnerText,
                    pubdate = DateTime.Parse(childrenNode["pubDate"].InnerText)
                });

            }

            return _db.Kaydet(haberler);


        }
    }
}
