using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GatewayLibrary.Records;

namespace GatewayLibrary.Databases
{
    public class GameElementDatabase : GameDatabase
    {

        #region Public Methods

        // Request the names of all items in database
        public List<string> RequestAllGameElementNames()
        {
            List<string> names = new List<string>();
            string requestAllCommandText = $"SELECT * FROM {databaseTableName}";
            SqlCommand requestAllCommand = new SqlCommand(requestAllCommandText, databaseConnection);

            // Read the account that matches the Username request
            using (SqlDataReader sqlReader = requestAllCommand.ExecuteReader())
            {
                while(sqlReader.Read()) {
                    // Store all gameElement data from the acquired SQL record in the GameElementRecord object
                    names.Add(sqlReader["Name"].ToString());
                }
            }
            return names;
        }
        // Requesting a specific item should be done in child class to fill that object specifically
        // Requesting all items should be done in child class to fill that object specifically
        // Add a new element should also be done in child class since it is record specific

        #endregion
    }
}
