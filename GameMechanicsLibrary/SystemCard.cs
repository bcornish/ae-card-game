using System;
using System.Collections.Generic;
using System.Text;
using GatewayLibrary.Databases;
using GatewayLibrary.Records;

namespace GameMechanicsLibrary
{
    public class SystemCard
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DesiredContent { get; set; }
        public decimal SignalAmplitude { get; set; }
        public int SignalFrequency { get; set; }
        public string SensorType { get; set; }
        public bool IsGrounded { get; set; }

        public void GenerateSystemByName(string name)
        {
            // Open Card Database
            SensorDatabase database = new SensorDatabase();
            database.OpenConnection();
            // Request CardRecord from Database
            SensorRecord record = database.RequestSensorByName(name);
            database.CloseConnection();
            // Map CardRecord to CardBaseModel
            PopulateSystemFromRecord(record);
        }

        public void PopulateSystemFromRecord(SensorRecord record)
        {
            Name = record.Name;
            Description = $"\"{record.Description}\"";
            DesiredContent = record.DesiredContent;
            SignalAmplitude = Convert.ToDecimal(record.SignalAmplitude);
            if (record.SignalFrequency != "DC")
            {
                SignalFrequency = Convert.ToInt32(record.SignalFrequency);
            }
            else
            {
                SignalFrequency = 0;
            }
            SensorType = record.Type;
            IsGrounded = (record.IsGrounded == "Yes");
        }
    }
}
