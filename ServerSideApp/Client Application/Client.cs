using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client_Application
{
    public class Client
    {
        public int MaxRetries { get; set; } = 5;
        //TODO:Change to dynamic value - throught protocol
        public byte[] Bytes = new byte[100];

        public IPHostEntry HostEntry { get; set; } 
        public IPAddress IpAddress => HostEntry.AddressList[6];
        public string HostName { get; set; }
        public Socket ClientSocket { get; set; }
        
        public string OutputMessage { get; set; }
        //TODO: Change to parameter adding of port, servername/ip address

        public int ConnectToServer(int portNumber)
        {
            try
            {
               // The end point - the server
                IPEndPoint serverEndPoint = new IPEndPoint(IpAddress, portNumber);
                // Creates a new socket through which the client will be able to connect to the server
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.Connect(serverEndPoint);
                OutputMessage = "Client successfully connected to " +
                    ClientSocket.RemoteEndPoint;
                return 0;
            }
            catch (Exception e)
            {
                throw (new Exception("ERROR Connecting to the server!\n" + e.Message));
            }
        }

        public int SendDataToServer(string message)
        {
            try
            {
                // Encode the data string into a byte array.
                byte[] msg = Encoding.ASCII.GetBytes(message + "<END_MESSAGE>");
                // Send the data through the socket.
                int bytesSent = ClientSocket.Send(msg);
                OutputMessage += "Sent " + bytesSent + " to the server!";
                return 0;
            }
            catch (ArgumentNullException argEx)
            {
                throw new Exception("ArgumentNullException : " + argEx.Message);
            }
            catch (SocketException socketEx)
            {
                throw new Exception("SocketException : " + socketEx.Message);
            }
            catch (Exception Ex)
            {
                throw new Exception("Unexpected exception :" + Ex.Message);
            }
        }
        public string ReceiveResponseFromServer()
        {
            try
            {
                // Receive the response from the remote device.
                int bytesReceived = ClientSocket.Receive(Bytes);
                return "Echoed test = " + Encoding.ASCII.GetString(Bytes, 0, bytesReceived);
            }
            catch (Exception e)
            {
                throw new Exception("ERROR receiving response from server!\n" + e.Message);
            }
        }
        public void ReleaseSocket()
        {       
            try
            {
                // Release the socket.
                ClientSocket.Shutdown(SocketShutdown.Both);
                ClientSocket.Close();
            }
            catch (Exception e)
            {
                OutputMessage += "ERROR RELEASING SOCKET! - TRIES LEFT: " + MaxRetries;

                while (MaxRetries > 0)
                {
                    MaxRetries--;
                    ReleaseSocket();
                }
                throw new Exception(OutputMessage);

            }
        }

        public Client()
        {
            HostName = Dns.GetHostName();
            HostEntry = Dns.GetHostEntry(HostName);

            OutputMessage += "Creating client " + HostEntry.HostName + " with IP address: " + IpAddress;

        }
    }
}
