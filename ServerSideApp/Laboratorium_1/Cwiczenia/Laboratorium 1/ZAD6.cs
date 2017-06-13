using System;
using System.Text.RegularExpressions;
using Laboratorium_1.Cwiczenia.Helpers;

namespace Laboratorium_1.Cwiczenia.Laboratorium_1
{
    public static class ZAD6
    {
        public static void Execute()
        {
            Console.WriteLine("Please give the IP address or hostname of the server:");
            string serverName = Console.ReadLine();
            while(ServerNameClassifier.DetermineNameClassification(serverName) == -1)
                Console.WriteLine("Server Name input is INVALID!\nPlease entar a valid host name or IP address!");

            Console.WriteLine("Connect on which port number? (Range 10 000 - 30 000)");
            string portNumber = Console.ReadLine();
            while(portNumber.Equals("") || PortVerifier.VerifyPortRange(Int32.Parse(portNumber)) == -1)
                Console.WriteLine("ERROR READING PORT NUMBER!\nPlease supply a value within the range 10000:30000");
                       
        }
    }
}
