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
            Console.WriteLine("read or write?");
            string response = Console.ReadLine();
            if (response == "write")
            {
                Console.WriteLine("Beginning Write Test...");
                AccountRecord testRecord = new AccountRecord();
                AccountDatabase database = new AccountDatabase();
                database.OpenConnection();
                //request dummy data
                Console.WriteLine("Please provide a username:");
                testRecord.Username = Console.ReadLine();
                Console.WriteLine("Please provide a password:");
                string password = Console.ReadLine();
                bool duplicateExists = database.AddAccountRecord(testRecord, password);
                if(duplicateExists)
                {
                    Console.WriteLine("A duplicate exists.  No account was created.  Try a different name.");
                }
                database.CloseConnection();
            }
            else
            {
                Console.WriteLine("Beginning Read Test...");
                AccountRecord testRecord = new AccountRecord();
                AccountDatabase database = new AccountDatabase();
                database.OpenConnection();
                //request dummy data
                Console.WriteLine("Please provide a username:");
                string username = Console.ReadLine();
                Console.WriteLine("Please provide a password:");
                string password = Console.ReadLine();
                testRecord = database.CheckAccountVsDatabase(username, password);
                Console.WriteLine($"Hello {testRecord.Username}!");
                Console.WriteLine(testRecord.ErrorString);
                database.CloseConnection();
            }
            Console.WriteLine("Nothing went wrong in this tests");
            Console.ReadLine();
        }
    }
}
