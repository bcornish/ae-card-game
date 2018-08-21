using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GatewayLibrary;

namespace TestConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            CardGameDatabase database = new CardGameDatabase();
            CardGameDatabase.OpenDatabaseConnection();

            Console.ReadLine();
        }
    }
}
