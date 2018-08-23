using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.SubSystems
{
    public class Signal
    {
        public int Frequency { get; private set; }
        public int Amplitude { get; private set; }

        public void WriteDummySignalProperties()
        {
            this.Frequency = 10000;
            this.Amplitude = 10;
        }
    }
}
