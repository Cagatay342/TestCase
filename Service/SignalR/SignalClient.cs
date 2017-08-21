using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SignalR
{
 public   class SignalClient
    {
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:49465/signalr";
        public HubConnection Connection { get; set; }

        public void Send(string Html)
        {
            HubProxy.Invoke("Send", "", Html);
        }
        public SignalClient()
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("ChatHub");


           // HubProxy.On<string, string>("AddMessage", (name, message) =>
           //    this.Dispatcher.Invoke(() =>
           //        RichTextBoxConsole.AppendText(String.Format("{0}: {1}\r", name, message))
           //    )
           //);

            try
            {
                 Connection.Start();
            }
            catch
            {

                return;
            }
        }



        /// <summary>
        /// If the server is stopped, the connection will time out after 30 seconds (default), and the 
        /// Closed event will fire.
        /// </summary>

    }
}
