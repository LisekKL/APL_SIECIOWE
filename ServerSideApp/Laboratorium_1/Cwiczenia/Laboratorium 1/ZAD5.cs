using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Laboratorium_1.Cwiczenia.Helpers;

namespace Laboratorium_1.Cwiczenia.Laboratorium_1
{
    public static class ZAD5
    {
        public static void Execute()
        {
            Console.WriteLine("Please supply a hostname to find its IP addresses");
            string hostname = Console.ReadLine();
            while (hostname != "X")
            {
                List<IPAddress> ipAddresses = IpAddressFinder.FindAddressByHostName(hostname);
                if (ipAddresses == null)
                {
                    Console.WriteLine("Host Name not valid!\n");
                }
                else
                {
                    string msg = "";
                    for (int i = 0; i < ipAddresses.Count; i++)
                    {
                        msg = ipAddresses[i].ToString();
                        if (i + 1 != ipAddresses.Count)
                            msg += ", ";
                    }
                    Console.WriteLine("IP ADDRESSES FOR HOSTNAME " + hostname + ":\n" + msg + "\n");
                }
                Console.WriteLine("Please supply a hostname to find its IP addresses");
                hostname = Console.ReadLine();
            }
        }
    }
}
