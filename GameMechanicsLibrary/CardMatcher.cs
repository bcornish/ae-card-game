using System;
using System.Collections.Generic;
using System.Text;

namespace GameMechanicsLibrary
{
    public class CardMatcher
    {
        // function that receives a card and a system and tells you whether they are compatible
        public bool CheckForMatch(Card card, SystemCard system)
        {
            bool match = true; // true until proven false by tests below

            // Step 1: See whether Sample Rate is adequate
            if (system.DesiredContent == "Frequency")
            {
                // Card must have 2x signal frequency as its sample rate
                if ((system.SignalFrequency*2) > card.SampleRate)
                {
                    match = false;
                }
            }
            else if (system.DesiredContent == "Waveform")
            {
                // Card must have 10x signal frequency as its sample rate
                if ((system.SignalFrequency*10) > card.SampleRate)
                {
                    match = false;
                }
            }
            else if (system.DesiredContent == "Level")
            {
                // Card frequency does not matter
            }
            // Step 2: Check for ground loops
            if (system.IsGrounded && (card.TerminalConfig == "Single-Ended"))
            {
                match = false;
            }
            // Step 3: Check for necessary Signal Conditioning
            if ((system.SensorType == "Thermocouple") && (card.SignalConditioning != "CJC"))
            {
                match = false;
            }
            else if ((system.SensorType == "Strain Gauge") && (card.SignalConditioning != "Bridge"))
            {
                match = false;
            }
            else if ((system.SensorType == "IEPE Microphone") && (card.SignalConditioning != "IEPE"))
            {
                match = false;
            }
            // Step 4:  Make sure signal Amplitude can be read
            if (system.SignalAmplitude > card.MeasurementRange)
            {
                match = false;
            }
            return match;
        }
    }
}
