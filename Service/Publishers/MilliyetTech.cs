using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Publishers
{
    class MilliyetTech : IPublisher
    {
        public string getUri()
        {
            return "http://www.milliyet.com.tr/rss/rssNew/teknolojiRss.xml";
        }
    }
}
