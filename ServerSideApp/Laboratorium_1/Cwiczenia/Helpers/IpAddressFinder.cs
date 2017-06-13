using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium_1.Cwiczenia.Helpers
{
    public static class IpAddressFinder
    {
        public static List<IPAddress> FindAddressByHostName(string hostname)
        {
            try
            {
                List<IPAddress> ipAddresses = new List<IPAddress>(Dns.GetHostAddresses(hostname));
                if (ipAddresses.Count == 0)
                {
                    return null;
                }
                return ipAddresses;
            }
            catch { }
            return null;
        }
    }
}
