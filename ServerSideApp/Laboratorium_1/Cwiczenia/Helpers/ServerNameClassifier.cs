using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratorium_1.Cwiczenia.Helpers
{
    public static class ServerNameClassifier
    {
        // checks te given name whether it's an IP Address (return 0) or HostName (return 1). If an error occured the value -1 is returned.
        public static int DetermineNameClassification(string serverName)
        {
            string ipRegex = "[0-9]*.[0-9]*.[0-9]*.[0-9]*";
            Regex varRegularExpression = new Regex(ipRegex);
            try
            {
                return varRegularExpression.IsMatch(serverName) ? 0 : 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR CHECKING SERVERNAME!\nErrorMessage:\n" + e.Message);
                return -1;
            }
        }
    }
}
