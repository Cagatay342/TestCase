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
            return Helper.Helper.db.Haberler.ToList();
        }

        public bool Kaydet(List<Haber> lh)
        {


            bool sonuc = false;
            List<Haber> Data;

            Data = Helper.Helper.db.Haberler.ToList();

            var Update = from first in lh
                                       join second in Data
                                       on first.guid equals second.guid 
                                       select first;

            var Insert = lh.Except(Update);

            //Insert = lh.Except(Data);
            //Update = Insert.Except(lh);

            foreach (Haber h in Insert)
            {
                Helper.Helper.db.Haberler.Add(h);
                sonuc = true;
            }

            foreach (Haber h in Update)
            {
                var result = Helper.Helper.db.Haberler.SingleOrDefault(b => b.guid == h.guid);
                if (result != null && result.pubdate != h.pubdate)
                {
                    result.pubdate = h.pubdate;
                    result.description = h.description;
                    result.link = h.link;
                    result.title = h.title;
                    sonuc=true;
                }
            }



            Helper.Helper.db.SaveChanges();
            return sonuc;

        }


    }
}
