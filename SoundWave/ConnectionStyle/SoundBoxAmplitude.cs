using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxAmplitude : IOutputable
    {
        protected readonly double fAmplitude;
        public SoundBoxAmplitude(double aAmplitude)
        {
            fAmplitude = aAmplitude;
        }
        public Output Output(double aMomentInSeconds)
        {
            return new Output(fAmplitude, null, null);
        }
        public IOutputable SignalOutput()
        {
            return this;
        }
    }

}
