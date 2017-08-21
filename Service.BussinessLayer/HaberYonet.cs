using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Models;


namespace Service.Bussines
{
   public class HaberYonet : IHaberYonet
    {
        public List<Haber> Goster()
        {
            return (new Models.Managers.DataBaseContext()).Haberler.ToList();
        }

        public string GosterTable()
        {
            List <Haber> x = Goster();

            string sonuc = DateTime.Now.ToString();
            sonuc = sonuc + "<table>";
            foreach(var item in x)
            {
                sonuc = sonuc + "<tr>";
                sonuc = sonuc + "<td>";
                sonuc = sonuc + item.title + "<br/>";
                sonuc = sonuc + "</td><td>";
                sonuc = sonuc + item.pubdate + "<br/>";
                sonuc = sonuc + "</td></tr>";

            }
            sonuc = sonuc + "</table>";

            return sonuc;

        }

        public List<Haber> Kaydet(List<Haber> lh)
        {


            List<Haber> sonuc = new List<Haber>();

            Models.Managers.DataBaseContext db = new Models.Managers.DataBaseContext();
            List<Haber> Data = db.Haberler.ToList();
            
            // Helper.Helper.db.Haberler.ToList();

            var Update = from first in lh
                                       join second in Data
                                       on first.guid equals second.guid 
                                       select first;

            var Insert = lh.Except(Update);

            //Insert = lh.Except(Data);
            //Update = Insert.Except(lh);

            foreach (Haber h in Insert)
            {
                db.Haberler.Add(h);
                sonuc.Add(h);
            }

            foreach (Haber h in Update)
            {
                var result = db.Haberler.SingleOrDefault(b => b.guid == h.guid);
                if (result != null && result.pubdate != h.pubdate)
                {
                    result.pubdate = h.pubdate;
                    result.description = h.description;
                    result.link = h.link;
                    result.title = h.title;
                    sonuc.Add(result);
                   
                }
            }



            db.SaveChanges();
            return sonuc;

        }


    }
}
