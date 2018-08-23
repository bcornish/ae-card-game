using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GatewayLibrary.Records;
using GatewayLibrary.Databases;

namespace TestConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Choose Test
            Console.WriteLine("account or gameElements?");
            string response1 = Console.ReadLine();
            
            // Test Accounts
            if (response1 == "account") {
                Console.WriteLine("read or write?");
                string response2 = Console.ReadLine();
                // Test Writing a New Account
                if (response2 == "write")
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
                    if (duplicateExists)
                    {
                        Console.WriteLine("A duplicate exists.  No account was created.  Try a different name.");
                    }
                    database.CloseConnection();
                }
                // Test Reading an Existing Account
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
                    testRecord = database.LookUpAccountRecord(username, password);
                    Console.WriteLine($"Hello {testRecord.Username}!");
                    Console.WriteLine(testRecord.ErrorString);
                    database.CloseConnection();
                }
            }
            // Test Other Database Activity
            else
            {
                Console.WriteLine("Beginning Other Database Test...");
                CardDatabase database = new CardDatabase();
                List<string> names = new List<string>();
                database.OpenConnection();
                // Test Pull All String Names
                names = database.RequestAllGameElementNames();
                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine("Test 1 Complete.");
                // Test Pull All Card Records
                List<CardRecord> records = new List<CardRecord>();
                records = database.RequestAllCards();
                foreach (CardRecord record in records) {
                    Console.WriteLine(record.Name);
                }
                Console.WriteLine("Test 2 Complete.");
                // Test Pull a Specific Card Record
                Console.WriteLine("Please Provide the name of one of the cards above (type exactly):");
                CardRecord card = database.RequestCardByName(Console.ReadLine());
                Console.WriteLine($"{card.Name},{card.ADCType},{card.IsMultiplexed},{card.SignalConditioning}");

                database.CloseConnection();

            }
            Console.WriteLine("Nothing went wrong in this tests");
            Console.ReadLine();
        }
    }
}
