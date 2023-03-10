using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxFrequencyMod : IOutputable
    {
        protected readonly double fFrequency;
        protected readonly double fFrequencyDiff;
        public SoundBoxFrequencyMod(double aFrequency, double aFrequencyDiff)
        {
            fFrequency = aFrequency;
            fFrequency = aFrequencyDiff;
        }

        public Output CalcOutput(double aMomentInSeconds)
        {
            return new Output(fFrequency, null);
        }

        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
