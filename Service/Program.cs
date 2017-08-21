using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Service.Bussines;
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
          

            Timer t = new Timer();
            t.Interval = 5000;
            t.Elapsed += T_Elapsed;
            t.Start();


            host = new ServiceHost(typeof(Service1), new Uri("http://localhost:5000/WPFHost/"));
            host.Open();

            
            Console.ReadLine();
            scon.Send("adsad");
            Console.ReadLine();
        }

        private static void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString() + " Parse Tetiklendi.");
            if (p.Parse())
            {
                //signalr ile yeni tabloyu gonder
                //mail gonder threadler ile 
                scon.Send("Naptın");
                Console.Write("SignalR tetiklendi");

            }
          
        }
    }
}
