using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GatewayLibrary.Records;
using System.Data.SqlClient;

namespace GatewayLibrary.Databases
{
    public class SensorDatabase : GameDatabase
    {
        public SensorDatabase()
        {
            databaseTableName = "SensorTable";
        }
        #region Public Methods

        // Request all sensors from sensor database
        public List<SensorRecord> RequestAllSensors()
        {
            List<SensorRecord> sensors = new List<SensorRecord>();
            string commandText = $"SELECT * FROM {databaseTableName}";
            SqlCommand command = new SqlCommand(commandText, databaseConnection);

            // Read the account that matches the Username request
            using (SqlDataReader sqlReader = command.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    // Store all gameElement data from the acquired SQL record in the GameElementRecord object
                    sensors.Add(ConvertSQLRowToRecord(sqlReader));
                }
            }
            return sensors;
        }
        // Request a single sensor by name
        public SensorRecord RequestSensorByName(string name)
        {
            SensorRecord sensor = new SensorRecord();
            string commandText = $"SELECT * FROM {databaseTableName} WHERE Name='{name}'";
            SqlCommand command = new SqlCommand(commandText, databaseConnection);

            // Read the account that matches the Username request
            using (SqlDataReader sqlReader = command.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    // Store all gameElement data from the acquired SQL record in the GameElementRecord object
                    sensor = (ConvertSQLRowToRecord(sqlReader));
                }
            }
            return sensor;
        }
        // Add a new sensor
        public void AddNewSensor(SensorRecord sensor)
        {
            string commandText = ConvertRecordToSQLCommand(sensor);
            ExecuteSqlSendCommand(commandText);
        }
        #endregion

        #region Private Methods
        private SensorRecord ConvertSQLRowToRecord(SqlDataReader sqlReader)
        {
            SensorRecord record = new SensorRecord();
            record.Name = sqlReader["Name"].ToString();
            record.Description = sqlReader["Description"].ToString();
            record.DesiredContent = sqlReader["DesiredContent"].ToString();
            record.SignalAmplitude = sqlReader["SignalAmplitude"].ToString();
            record.SignalFrequency = sqlReader["SignalFrequency"].ToString();
            record.Type = sqlReader["Type"].ToString();
            record.IsGrounded = sqlReader["IsGrounded"].ToString();
            return record;
        }
        private string ConvertRecordToSQLCommand(SensorRecord record)
        {
            string commandText = $"INSERT INTO {databaseTableName} (Name, Description, SignalAmplitude, SignalFrequency," +
                                 $" DesiredContent, Type, IsGrounded) " +
                                 $"VALUES ('{record.Name}','{record.ImageLocation}','{record.Description}','{record.SignalAmplitude}','{record.SignalFrequency}'," +
                                 $"'{record.DesiredContent}','{record.Type}','{record.IsGrounded}');";
            return commandText;
        }
        #endregion
    }
}

