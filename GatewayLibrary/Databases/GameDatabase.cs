using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GatewayLibrary
{
    /*the CardGameDatabase class connects 
     * to the SQL Server to send/receive information 
     * to and from the NICardGame database
     */

    public class GameDatabase
    {
       protected SqlConnection databaseConnection { get; set; }

        //opens a connection to the SQL database
        public void OpenConnection()
        {
            //define connection string for connecting to the SQL Server database
            string userID = "cardGame";
            string password = "3as^3as^";
            string server = "PAPOWER-DTTEST";
            string database = "NICardGame";
            string connectionString = $"user id={userID};password={password};" +
                                      $"server={server};database={database};";
            //connect to the NICardGame database 
            //***(if connection fails, need a better method of error handling!)***
            databaseConnection = new SqlConnection(connectionString);
            try
            {
                databaseConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        //this function executes a sql command to send something to the database
        protected void ExecuteSqlSendCommand(string commandText)
        {
            SqlCommand command = new SqlCommand(commandText, databaseConnection);
            command.ExecuteNonQuery();
        }

        //closes the connection to the SQL database
        public void CloseConnection()
        {
            databaseConnection.Close();
        }

    }
}
