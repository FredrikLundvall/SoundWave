using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxFrequency : SoundBoxBase
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

        override public Output OutputValue(double aMomentInSeconds)
        {
            return new Output(fFrequency, nfmod(aMomentInSeconds / (1.0 / fFrequency), 1.0) );
        }
    }
}
