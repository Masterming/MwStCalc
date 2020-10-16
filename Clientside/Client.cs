using Services;
using System.ServiceModel;

namespace Clientside
{
    class Client
    {
        public readonly string ip;
        public readonly int port;
        public readonly string ServiceName;
        public string svcAddress;

        public Client(string ip, int port)
        {
            // Address
            this.ip = ip;
            this.port = port;
            this.ServiceName = "MathService";
            svcAddress = ip + ":" + port + "/" + ServiceName;
        }

        public double RequestPercentage(int id)
        {
            // Binding
            NetTcpBinding tcpb = new NetTcpBinding(SecurityMode.Message);
            ChannelFactory<IService> factory = new ChannelFactory<IService>(tcpb);

            // Endpoint
            EndpointAddress address = new EndpointAddress(svcAddress);

            // Create Channel
            IService calcService = factory.CreateChannel(address);

            double res = 0.0;
            try
            {
                res = calcService.GetMwStPerc(id);
            }
            catch (EndpointNotFoundException)
            {
                System.Diagnostics.Trace.WriteLine("Connection to sever failed");
            }
            finally
            {
            factory.Close();
            }
            return res;
        }
    }
}
