using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Bussines
{
   public interface IHaberYonet
    {

        List<Haber> Kaydet(List<Haber> lh);

        List<Haber> Goster();

        string GosterTable();

        List<Kisi> GosterKisi();


    }
}
