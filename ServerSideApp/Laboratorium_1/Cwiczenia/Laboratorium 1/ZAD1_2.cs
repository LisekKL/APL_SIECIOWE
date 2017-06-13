using System;
using Laboratorium_1.Cwiczenia.Helpers;

namespace Laboratorium_1.Cwiczenia.Laboratorium_1
{
    public static class ZAD1_2
    {
        public static void Execute()
        {
            Console.WriteLine("Please supply the path to the source file:");
            string path = Console.ReadLine();
            Laboratorium1 lab1 = new Laboratorium1(path, 1);
            int code = lab1.Execute();
            Console.WriteLine(code == 0 ? "LABORATORIUM 1 COMPLETED!" : "APPLICATION ENDED WITH ERRORS!");
        }
    }
}
