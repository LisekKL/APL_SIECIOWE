using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerSideApp.DAL
{
    public class ServerProgram
    {
        public IPAddress IpAddress = IPAddress.Parse("192.168.0.11");
        public TcpListener MyTcpListener = new TcpListener(IpAddress,8000);

    }
}
