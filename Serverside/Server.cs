using Services;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Serverside
{
    class Server
    {
        public readonly string ip;
        public readonly int port;
        public readonly string ServiceName;
        private ServiceHost sh;

        public Server(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            this.ServiceName = "MathService";
        }

        public void Run()
        {
            string svcAddress = ip + ":" + port + "/" + ServiceName;
            Uri svcUri = new Uri(svcAddress);

            using (sh = new ServiceHost(typeof(Service), svcUri))
            {
                // Binding
                NetTcpBinding tcpBinding = new NetTcpBinding(SecurityMode.Message);

                // Behavior
                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                sh.Description.Behaviors.Add(behavior);
                sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

                //Endpoint
                sh.AddServiceEndpoint(typeof(IService), tcpBinding, svcAddress);

                // Open
                sh.Open();

                Console.WriteLine("Service started '" + svcAddress);

                Console.WriteLine("Press any key to close.");
                Console.ReadKey();
                sh.Close();
            }
        }
    }
}
