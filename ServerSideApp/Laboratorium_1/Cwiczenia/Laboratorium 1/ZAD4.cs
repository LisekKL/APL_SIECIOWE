using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorium_1.Cwiczenia.Helpers;

namespace Laboratorium_1.Cwiczenia.Laboratorium_1
{
    public static class ZAD4
    {
        public static void Execute()
        {
            Console.WriteLine("Please supply an IP Address for finding its hostname:");
            int counter = 1;
            Console.WriteLine("TEST NR " + counter);
            string address = Console.ReadLine();
            while (address != "X")
            {
                if (IPAddressVerifier.CheckAddress(address) == 0)
                {
                    string host = HostNameFinder.GetHostNameFromIP(address);
                    Console.WriteLine(host == null
                        ? "HOSTNAME NOT FOUND!\n"
                        : "HOSTNAME OF IP ADDRESS " + address + " IS " + host + "\n");
                }
                else Console.WriteLine("IP ADDRESS NOT VALID!\n");
                counter++;
                Console.WriteLine("TEST NR " + counter);
                address = Console.ReadLine();
            }
        }
    }
}
