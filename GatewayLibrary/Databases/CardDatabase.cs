using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GatewayLibrary.Records;
using System.Data.SqlClient;

namespace GatewayLibrary.Databases
{
    public class CardDatabase : GameElementDatabase
    {
        public CardDatabase()
        {
            databaseTableName = "ModuleTable";
        }
        #region Public Methods

        // Request all cards from card database
        public List<CardRecord> RequestAllCards()
        {
            List<CardRecord> cards = new List<CardRecord>();
            string commandText = $"SELECT * FROM {databaseTableName}";
            SqlCommand command = new SqlCommand(commandText, databaseConnection);

            // Read the account that matches the Username request
            using (SqlDataReader sqlReader = command.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    // Store all gameElement data from the acquired SQL record in the GameElementRecord object
                    cards.Add(ConvertSQLRowToRecord(sqlReader));
                }
            }
            return cards;
        }
        // Request a single card by name
        public CardRecord RequestCardByName(string name)
        {
            CardRecord card = new CardRecord();
            string commandText = $"SELECT * FROM {databaseTableName} WHERE Name='{name}'";
            SqlCommand command = new SqlCommand(commandText, databaseConnection);

            // Read the account that matches the Username request
            using (SqlDataReader sqlReader = command.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    // Store all gameElement data from the acquired SQL record in the GameElementRecord object
                    card = (ConvertSQLRowToRecord(sqlReader));
                }
            }
            return card;
        }
        // Add a new card
        public void AddNewModuleCard(CardRecord record)
        {
            string commandText = ConvertRecordToSQLCommand(record);
            ExecuteSqlSendCommand(commandText);
        }
        #endregion

        #region Private Methods
        private CardRecord ConvertSQLRowToRecord(SqlDataReader sqlReader)
        {
            CardRecord record = new CardRecord();
            record.Name = sqlReader["Name"].ToString();
            record.Description = sqlReader["Description"].ToString();
            record.Cost = sqlReader["Cost"].ToString();
            record.ADCType = sqlReader["ADCType"].ToString();
            record.SignalConditioning = sqlReader["SignalConditioning"].ToString();
            record.TerminalConfig = sqlReader["TerminalConfig"].ToString();
            record.MeasurementRange = sqlReader["MeasurementRange"].ToString();
            record.SampleRate = sqlReader["SampleRate"].ToString();
            record.IsMultiplexed = sqlReader["IsMultiplexed"].ToString();
            return record;
        }
        private string ConvertRecordToSQLCommand(CardRecord record)
        {
            string commandText = $"INSERT INTO {databaseTableName} (Name, Description, ADCType, SignalConditioning," +
                                 $" Cost, TerminalConfig, MeasurementRange, SampleRate, IsMultiplexed) " +
                                 $"VALUES ('{record.Name}','{record.ImageLocation}','{record.Description}','{record.ADCType}','{record.SignalConditioning}'," +
                                 $"'{record.Cost}','{record.TerminalConfig}','{record.MeasurementRange}','{record.SampleRate}','{record.IsMultiplexed}');";
            return commandText;
        }
        #endregion
    }
}
