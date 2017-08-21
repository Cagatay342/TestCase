/*
 NOTLAR

1-) Static DbContextlerde datayi elle degistirdigimde guncellemedigi icin her seferinde tekrar new ile olusturdum.
 
 
 */


using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Service.Bussines;
using Service.Models;
using Service.Models.Managers;
using Service.Parsers;
using Service.Publishers;
using Service.SignalR;
using Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Service
{
    
    class Program
    {
        static IParser p;
        static ServiceHost host;
        static SignalClient scon = new SignalClient();
        static void registerCastle()
        {

            Helper.Helper._container = new WindsorContainer();
            Helper.Helper._container.Register(
                 Component.For<IPublisher>().ImplementedBy<MilliyetTech>(),
                 Component.For<IParser>().ImplementedBy<Parser>(),
                 Component.For<IHaberYonet>().ImplementedBy<HaberYonet>()
                );

        }

        static void Main(string[] args)
        {

            
            
            
            registerCastle();

            //Timer baslatilip olusturulan Iparse ozellikli class ın parse fonksiyonu belli aralıklarla calistirlacak
            //wcf servici baslatilacak duplex olarak


            p = Helper.Helper._container.Resolve<IParser>();



            Console.WriteLine("Sistem Hazırlanıyor");


            //wcf servisini baslatiliyor
            host = new ServiceHost(typeof(Service1), new Uri("http://localhost:5000/WPFHost/"));
            host.Open();



            //Website biraz gec aciliacagi icin Websitenin kendine gelmesini bekle
            System.Threading.Thread.Sleep(10000);


            //Belli saniyede parser classının parse fonksiyonun cagirlaım 
            Timer t = new Timer();
            t.Interval = 5000;
            t.Elapsed += T_Elapsed;
            t.Start();




            Console.ReadLine();
        }

        private static void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            //biri bitmeden digeri baslamasın
            ((Timer)sender).Stop();
            Console.WriteLine(DateTime.Now.ToString() + " Parse Tetiklendi.");


            //varsa degisiklikleri listeye alalım ona gore ekranları yenileyecegiz ve mail atma islemini baslatacagız 

            List<Haber> x = p.Parse();

            if (x.Count>0)
            {
                //signalr ile yeni tabloyu gonder
                //html ciktisini hazirlayip tum browserlarda otomatik yenileyelim
                IHaberYonet _db = Helper.Helper._container.Resolve<IHaberYonet>();
                scon.Send(_db.GosterTable());



                //mail gonder threadler ile 

                Console.WriteLine(DateTime.Now.ToString() + " SignalR tetiklendi");



            }

            //islem bitti timeri tekrar baslatabiliriz.
            ((Timer)sender).Start();

        }
    }
}
