using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxFrequency : IOutputable
    {
        protected readonly decimal fFrequency;
        public SoundBoxFrequency(decimal aFrequency)
        {
            fFrequency = aFrequency;
        }

        //static public decimal nfmod(decimal a, decimal b)
        //{
        //    return a - b * Math.Floor(a / b);
        //}

        public Output CalcOutput(decimal aMomentInSeconds)
        {
            return new Output(fFrequency, null);// nfmod(aMomentInSeconds / (1.0 / fFrequency), 1.0));
        }

        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
