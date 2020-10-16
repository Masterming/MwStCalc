namespace Serverside
{
    class Program
    {
        static void Main()
        {
            Server server = new Server("net.tcp://localhost", 31227);
            server.Run();
        }
    }
}
