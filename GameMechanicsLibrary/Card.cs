using System;
using System.Collections.Generic;
using System.Text;
using GatewayLibrary.Databases;
using GatewayLibrary.Records;

namespace GameMechanicsLibrary
{
    public class Card
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public string ADCType { get; set; }
        public string SignalConditioning { get; set; }
        public string TerminalConfig { get; set; }
        public decimal MeasurementRange { get; set; }
        public int SampleRate { get; set; }
        public bool IsMultiplexed { get; set; }

        public void GenerateCardByName(string name)
        {
            // Open Card Database
            CardDatabase database = new CardDatabase();
            database.OpenConnection();
            // Request CardRecord from Database
            CardRecord card = new CardRecord();
            card = database.RequestCardByName(name);
            database.CloseConnection();
            // Map CardRecord to CardBaseModel
            PopulateCardFromRecord(card);
        }

        public void PopulateCardFromRecord(CardRecord record)
        {
            Name = record.Name;
            Description = $"\"{record.Description}\"";
            Cost = Convert.ToInt32(record.Cost);
            ADCType = record.ADCType;
            SignalConditioning = record.SignalConditioning;
            TerminalConfig = record.TerminalConfig;
            MeasurementRange = Convert.ToDecimal(record.MeasurementRange);
            SampleRate = Convert.ToInt32(record.SampleRate);
            IsMultiplexed = (record.IsMultiplexed == "Yes");
        }
    }
}
