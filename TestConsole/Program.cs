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
            Console.WriteLine("Beginning Test...");
            AccountDatabase database = new AccountDatabase();
            database.OpenConnection();
            AccountRecord dummyRecord = new AccountRecord();
            dummyRecord.userName = "pineappleMan";
            string dummyPassword = "easypassword";
            database.AddAccountRecord(dummyRecord, dummyPassword);
            Console.WriteLine("AccountRecord Added! Waiting to end");
            Console.ReadLine();
        }
    }
}
