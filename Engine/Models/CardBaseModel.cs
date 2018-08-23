﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GatewayLibrary.Databases;
using GatewayLibrary.Records;

namespace Engine.Models
{
    
    public class CardBaseModel : BaseModel
    {
        #region Original Properties
        private string modelNumber;
        private string specifications;
        private string cardBaseImage;
        private string price;
        private int height;
        private int width;

        public CardBaseModel()
        {
            modelNumber = null;
            specifications = null;
            cardBaseImage = null;
            price = null;
            height = 200;
            width = 100;
        }
        public string ModuleNumber
        {
            get { return modelNumber; }
            set
            {
                modelNumber = value;

                OnPropertyChanged(nameof(ModuleNumber));
            }
        }
        public string ModuleSpecs
        {
            get { return specifications; }
            set
            {
                specifications = value;

                OnPropertyChanged(nameof(ModuleSpecs));
            }
        }
        public string ModulePrice
        {
            get { return price; }
            set
            {
                price = value;

                OnPropertyChanged(nameof(ModulePrice));
            }
        }
        public string CardBaseImage
        {
            get { return cardBaseImage; }
            set
            {
                cardBaseImage = value;

                OnPropertyChanged(nameof(CardBaseImage));
            }
        }
        #endregion


        public int Width
        {
            get { return width; }
            set
            {
                width = value;

                OnPropertyChanged(nameof(Width));
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                width = value;

                OnPropertyChanged(nameof(Height));
            }
        }


        public string Name { get; private set; }
        public string ImageLocation { get; private set; }
        public string Description { get; private set; }
        public int Cost { get; private set; }
        public string ADCType { get; private set; }
        public string SignalConditioning { get; private set; }
        public string TerminalConfig { get; private set; }
        public int MeasurementRange { get; private set; }
        public int SampleRate { get; private set; }
        public bool IsMultiplexed { get; private set; }

        public void WriteDummyCardData()
        {
            Name = "NI 9215";
            ImageLocation = "pack://application:,,,/Window;component/Blank Fake Card.bmp";
            Description = "This is a C Series Module.  It reads signals";
            ADCType = "SAR";
            SignalConditioning = "None"; // Could also be "Bridge Completion", "CJC", "IEPE"
            TerminalConfig = "Differential"; // Could also be "Single-Ended"
            MeasurementRange = 10;
            SampleRate = 100000;
            IsMultiplexed = false;
        }

        public void MapCardRecordToModel(string name)
        {
            // Open Card Database
            CardDatabase database = new CardDatabase();
            // Request
            CardRecord card = database.RequestCardByName(name);
            Name = card.Name;
            ImageLocation = card.ImageLocation;
            Description = card.Description;
            Cost = Convert.ToInt32(card.Cost);
            ADCType = card.ADCType;
            SignalConditioning = card.SignalConditioning;
            TerminalConfig = card.TerminalConfig;
            MeasurementRange = Convert.ToInt32(card.MeasurementRange);
            SampleRate = Convert.ToInt32(card.SampleRate);
            IsMultiplexed = (card.IsMultiplexed == "Yes");
        }

        private string GenerateModuleSpecsText()
        {
            string text = null;
            string samplingType = "Simultaneous";
            if (IsMultiplexed)
            {
                samplingType = "Multiplexed";
            }
            text = $"Description: {Description}\n" +
                   $"ADC Type: {ADCType}\n" +
                   $"Signal Conditioning: {SignalConditioning}\n" +
                   $"TerminalConfig: {TerminalConfig}\n" +
                   $"Measurement Range: ±{MeasurementRange} V\n" +
                   $"Sample Rate: {SampleRate} Hz\n" +
                   $"Sampling Architecture: {samplingType}\n";
            return text;
        }


        public string Name { get; private set; }
        public string ImageLocation { get; private set; }
        public string Description { get; private set; }
        public int Cost { get; private set; }
        public string ADCType { get; private set; }
        public string SignalConditioning { get; private set; }
        public string TerminalConfig { get; private set; }
        public int MeasurementRange { get; private set; }
        public int SampleRate { get; private set; }
        public bool IsMultiplexed { get; private set; }

        public void WriteDummyCardData()
        {
            Name = "NI 9215";
            ImageLocation = "pack://application:,,,/Window;component/Blank Fake Card.bmp";
            Description = "This is a C Series Module.  It reads signals";
            ADCType = "SAR";
            SignalConditioning = "None"; // Could also be "Bridge Completion", "CJC", "IEPE"
            TerminalConfig = "Differential"; // Could also be "Single-Ended"
            MeasurementRange = 10;
            SampleRate = 100000;
            IsMultiplexed = false;
        }

        public void MapCardRecordToModel(string name)
        {
            // Open Card Database
            CardDatabase database = new CardDatabase();
            // Request
            CardRecord card = database.RequestCardByName(name);
            Name = card.Name;
            ImageLocation = card.ImageLocation;
            Description = card.Description;
            Cost = Convert.ToInt32(card.Cost);
            ADCType = card.ADCType;
            SignalConditioning = card.SignalConditioning;
            TerminalConfig = card.TerminalConfig;
            MeasurementRange = Convert.ToInt32(card.MeasurementRange);
            SampleRate = Convert.ToInt32(card.SampleRate);
            IsMultiplexed = (card.IsMultiplexed == "Yes");
        }

        private string GenerateModuleSpecsText()
        {
            string text = null;
            string samplingType = "Simultaneous";
            if (IsMultiplexed)
            {
                samplingType = "Multiplexed";
            }
            text = $"Description: {Description}\n" +
                   $"ADC Type: {ADCType}\n" +
                   $"Signal Conditioning: {SignalConditioning}\n" +
                   $"TerminalConfig: {TerminalConfig}\n" +
                   $"Measurement Range: ±{MeasurementRange} V\n" +
                   $"Sample Rate: {SampleRate} Hz\n" +
                   $"Sampling Architecture: {samplingType}\n";
            return text;
        }
        public void ImageSourceLookup()
        {
            MapCardRecordToModel("NI 9215"); 
            CardBaseImage = "pack://application:,,,/Window;component/Blank Fake Card.bmp";
            //"pack://application:,,,/Window;component/Blank Fake Card.bmp"
            ModuleNumber = Name;
            ModulePrice = $"${Cost}";
            ModuleSpecs = GenerateModuleSpecsText();
                       
    }
    }
}
