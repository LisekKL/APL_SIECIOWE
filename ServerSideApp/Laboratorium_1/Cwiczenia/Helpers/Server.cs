using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Laboratorium_1.Cwiczenia.Helpers
{
    public class Server
    {
        //represents the port on which the serwer will listen
        private int _portNumber = 10000;
        //Represents the maximum length of the connection queue
        private int _maxQueue = 10;
        //Sets ip address of server - my local ip address - FOR TESTING PURPOSES ONLY! NO HARDCODE ALLOWED - GET DYNAMIC IP INSTEAD
        //public IPAddress ServerIpAddress => IPAddress.Parse("192.168.0.11");
        //Sets ip address dynamically - USE THIS
            //gets the current HostEntry from the DNS server by looking for it's own hostname (asks for own IP address)
        public IPHostEntry HostEntry { get; set; } = Dns.GetHostEntry(Dns.GetHostName());
        public IPAddress ServerIpAddress => HostEntry.AddressList[0];

        //Creates socket address for endpoint
        public IPEndPoint EndPoint { get; set; }
        public Socket ServerSocket { get; set; }      

        //TODO: Change to queue of clients
        public Socket ClientSocket { get; set; }

        public Server()
        {
            Console.WriteLine("Starting server...");
            Thread.Sleep(2000);
            EndPoint = new IPEndPoint(ServerIpAddress, _portNumber);
            Console.WriteLine("Setting up end point at " + ServerIpAddress + " on port " + _portNumber + "...");
            Thread.Sleep(1000);
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerSocket.Bind(EndPoint);
            ServerSocket.Listen(_maxQueue);
            Console.WriteLine("Server up and listening on port " + _portNumber);

            ServerSocket.Accept();
        }
    }
}
