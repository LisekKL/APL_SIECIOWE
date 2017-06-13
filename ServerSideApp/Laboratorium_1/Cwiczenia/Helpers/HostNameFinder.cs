using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium_1.Cwiczenia.Helpers
{
    public static class HostNameFinder
    {
        public static string GetHostNameFromIP(string ipAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null) return entry.HostName;
            }
            catch {}
            return null;
        }

    }
}
