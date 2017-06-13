using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium_1.Cwiczenia.Helpers
{
    public static class IPAddressVerifier
    {
        public static int CheckAddress(string address)
        {
            try
            {
                IPAddress.Parse(address);
            }
            catch
            {
                return -1;
            }
            return 0;
        }
    }
}
