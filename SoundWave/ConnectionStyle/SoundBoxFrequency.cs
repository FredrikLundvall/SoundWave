using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxFrequency : IOutputable
    {
        protected readonly double fFrequency;
        public SoundBoxFrequency(double aFrequency)
        {
            fFrequency = aFrequency;
        }

        static public double nfmod(double a, double b)
        {
            return a - b * Math.Floor(a / b);
        }

        public Output Output(double aMomentInSeconds)
        {
            return new Output(0, nfmod(aMomentInSeconds / (1.0 / fFrequency), 1.0), fFrequency);
        }

        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
