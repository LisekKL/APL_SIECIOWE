using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium_1.Cwiczenia.Helpers
{
    public class Server
    {
        //Sets ip address of server - my local ip address
        public IPAddress ServerIpAddress => IPAddress.Parse("192.168.0.11");

        Socket TestApplicationSocket = new Socket(SocketType.Stream,ProtocolType.Unspecified);
    }
}
