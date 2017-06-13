using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium_1.Cwiczenia.Helpers
{
    public static class PortVerifier
    {
        //Verifies the range of the given port. The application only allows for ports within the range of 10 000 - 30 000
        public static int VerifyPortRange(int portNumber)
        {
            return (portNumber < 10000 || portNumber > 30000) ? -1 : 0;
        }
    }
}
