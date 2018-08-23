using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GatewayLibrary
{
    /* The CardGameDatabase class connects 
     * to the SQL Server to send/receive information 
     * to and from the NICardGame database
     */

    public class GameDatabase
    {
       protected SqlConnection databaseConnection { get; set; }

        // Opens a connection to the SQL database
        public void OpenConnection()
        {
            // Defines the SQL string for connecting to the SQL Server database
            string userID = "cardGame";
            string password = "3as^3as^";
            string server = "PAPOWER-DTTEST";
            string database = "NICardGame";
            string connectionString = $"user id={userID};password={password};" +
                                      $"server={server};database={database};";
            // Connects to the NICardGame database 
            databaseConnection = new SqlConnection(connectionString);
            try
            {
                databaseConnection.Open();
            }
            catch (Exception e)
            {
                //TODO:  Implement Error message if database connection fails
            }
        }
        // This function executes a SQL command to send a generic record to the database (SQL String defined by caller)
        protected void ExecuteSqlSendCommand(string commandText)
        {
            SqlCommand command = new SqlCommand(commandText, databaseConnection);
            command.ExecuteNonQuery();
        }

        // Closes the connection to the SQL database
        public void CloseConnection()
        {
            databaseConnection.Close();
        }

    }
}
