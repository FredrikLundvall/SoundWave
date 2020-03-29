using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxFrequencyFM : IOutputable
    {
        protected readonly decimal fFrequency;
        public SoundBoxFrequencyFM(decimal aFrequency)
        {
            fFrequency = aFrequency;
        }

        public Output CalcOutput(decimal aMomentInSeconds)
        {
            return new Output(fFrequency, Output.ConvertFrequencyToPhase(aMomentInSeconds, fFrequency));
        }

        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
}
