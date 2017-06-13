using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorium_1.Cwiczenia.Helpers;

namespace Laboratorium_1.Cwiczenia.Laboratorium_1
{
    public static class ZAD3
    {
        public static void Execute()
        {
            Console.WriteLine("Please supply an IP Address for verification:");
            string address = Console.ReadLine();
            Console.WriteLine(IPAddressVerifier.CheckAddress(address) == 0
                ? "IP ADDRESS VALID!"
                : "IP ADDRESS NOT VALID!");
        }
    }
}
