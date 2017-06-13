using System;
using System.IO;

namespace Laboratorium_1.Cwiczenia.Helpers
{
    public class Laboratorium1
    {
        public string SourceFilePath { get; set; } 
        public string DestinationFilePath { get; set; }
        public string Message { get; set; }
        public int MessageType { get; set; }
        public Laboratorium1(string fileName, int flag)
        {
            MessageType = flag;
            SourceFilePath = @"C:\Users\Karol\Desktop\APLIKACJE SIECIOWE\TEST FOLDER\" + fileName;
            if (MessageType == 1)
                DestinationFilePath = @"C:\Users\Karol\Desktop\APLIKACJE SIECIOWE\TEST FOLDER\lab1zad1.txt";
            else if(MessageType == 2)
                DestinationFilePath = @"C:\Users\Karol\Desktop\APLIKACJE SIECIOWE\TEST FOLDER\lab1zad2.png";
        }

        public int Execute()
        {
            Message = ReadFile();
            if (Message == null) return 1;
            WriteMessageToFile(Message);
            return 0;
        }

        public string ReadFile()
        {
            Console.Clear();
            Console.WriteLine("Opening file " + SourceFilePath);
            if (!File.Exists(SourceFilePath))
            {
                Console.WriteLine("SOURCE FILE DOESN'T EXIST!\nEXITING...");
                return null;
            }
            Console.WriteLine("Reading file content...");
            string msg = "";
            if (MessageType == 1) msg = File.ReadAllText(SourceFilePath);
            else if (MessageType == 2) msg = Convert.ToBase64String(File.ReadAllBytes(SourceFilePath));
            Console.WriteLine("THIS MESSAGE WAS READ: \n" + msg);
            return msg;
        }

        public void WriteMessageToFile(string message)
        {
            Console.Clear();
            if (message == null) return;
            Console.WriteLine("Checking if file exists....");
            if (!File.Exists(DestinationFilePath))
            {
                if (MessageType == 1)
                    File.WriteAllText(DestinationFilePath, message);
                else if(MessageType == 2) 
                    File.WriteAllBytes(DestinationFilePath, Convert.FromBase64String(message));
            }
            else File.AppendAllText(DestinationFilePath,message);
        }

    }
}
