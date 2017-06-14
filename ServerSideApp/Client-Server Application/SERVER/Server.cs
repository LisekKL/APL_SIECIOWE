using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client_Server_Application.SERVER
{
    public class Server
    {
        public int MaxRetriesLeft = 5;
        //Represents the maximum size of package to receive (bytes)
        //TODO: ma być ustalone!!!!!!!!!!!!!!!!!!!!
        private int _packageSize = 100;
        //represents the port on which the serwer will listen
        private int _portNumber = 10000;
        //Represents the maximum length of the connection queue
        private int _maxQueue = 10;
        //Sets ip address of server - my local ip address - FOR TESTING PURPOSES ONLY! NO HARDCODE ALLOWED - GET DYNAMIC IP INSTEAD
        //public IPAddress ServerIpAddress => IPAddress.Parse("192.168.0.11");
        //Sets ip address dynamically - USE THIS
            //gets the current HostEntry from the DNS server by looking for it's own hostname (asks for own IP address)
        public IPHostEntry HostEntry { get; set; } 
        public IPAddress ServerIpAddress => HostEntry.AddressList[6];

        //Creates socket address for endpoint
        public IPEndPoint EndPoint { get; set; }
        public Socket ServerSocket { get; set; }      
        //TODO: Change to queue of clients
        public Socket ClientSocket { get; set; }

        public void Start(int portNumber)
        {
            try
            {
                EndPoint = new IPEndPoint(ServerIpAddress, portNumber);
                Console.WriteLine("Setting up end point at " + ServerIpAddress + " on port " + portNumber + "...");
                Thread.Sleep(1000);
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerSocket.Bind(EndPoint);
                ServerSocket.Listen(_maxQueue);
                Console.WriteLine("Server up and listening on port " + portNumber + "...");
                Connect();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error initiating server!\nStackTrace = \n" + e.StackTrace);
            }
        }

        public void Connect()
        {
            Console.WriteLine("Connecting to client...");
            Thread.Sleep(1000);
            try
            {
                //AsyncCallback asyncCallBack = new AsyncCallback();
                ClientSocket = ServerSocket.Accept();
                Console.Clear();
                Console.WriteLine("Accepted connection to host " + ClientSocket.RemoteEndPoint);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error connecting to client!\nStackTrace =\n" + e.StackTrace);
            }
        }

        public void ReceiveData()
        {
            try
            {
                byte[] b = new byte[_packageSize];
                int bytesReceivedCount = ServerSocket.Receive(b);
                Console.WriteLine("Received " + bytesReceivedCount + "...");
                for (int i = 0; i < bytesReceivedCount; i++)
                    Console.Write(Convert.ToChar(b[i]));
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR OCCURED WHILE RECEIVING DATA!\nStackTrace = \n" + e.StackTrace);
            }
        }

        public void SendAcknowledgment()
        {
            try
            {
                ASCIIEncoding enc = new ASCIIEncoding();
                ServerSocket.Send(enc.GetBytes("The string was received by the server."));
                Console.WriteLine("\nSent Acknowledgement");
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR SENDING MESSAGE RECEIVED ACKNOWLEDGMENT!\nStackTrace = \n" + e.StackTrace);
            }
        }

        public void ShutDown()
        {
            try
            {
                Console.WriteLine("Closing socket connection...");
                Thread.Sleep(1000);
                // Release the socket.
                ServerSocket.Shutdown(SocketShutdown.Both);
                ServerSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR SHUTTING DOWN SERVER! - TRIES LEFT: " + MaxRetriesLeft);
                while (MaxRetriesLeft > 0)
                {
                    MaxRetriesLeft--;
                    ShutDown();
                }
            }
        }

        public Server()
        {
            HostEntry = Dns.GetHostEntry(Dns.GetHostName());
            Console.WriteLine("Starting server...");
            Thread.Sleep(2000);
            try
            {
                Start(_portNumber);
                //Connect();
               // ReceiveData();
                //SendAcknowledgment();
                //ShutDown();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR IN CONNECTION!\n" + e.StackTrace);
            }
            
        }
    }
}
