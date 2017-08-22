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
        //Cekilecek Xml hangi yayincinin
        IPublisher _pub=null;

        //database contexi iceren manager
        IHaberYonet _db = null;


        public  Parser()
        {
            _pub = Helper.Helper._container.Resolve<IPublisher>();
            _db = Helper.Helper._container.Resolve<IHaberYonet>();
        }

   
        //Linkden Xmli download edecek fonksiyon
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
            //xmli indrileim yayincidan gelen uri ile 
            string Xml = GetXml(_pub.getUri());


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(Xml);



            string xpath = _pub.getXpath();
            var nodes = xmlDoc.SelectNodes(xpath);

            List<Haber> haberler = new List<Haber>();

            //Cekilen xml nesnlerini listeye atalim
            foreach (XmlNode childrenNode in nodes)
            {
                haberler.Add(_pub.getHaber(childrenNode));

            }

            //Listeyi managera kayit edildmek uzere gonderebiliriz.
            return _db.Kaydet(haberler);


        }
    }
}
