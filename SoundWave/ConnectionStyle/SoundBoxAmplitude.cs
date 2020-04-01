using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxAmplitude : IOutputable
    {
        protected readonly decimal fAmplitude;
        public SoundBoxAmplitude(decimal aAmplitude)
        {
            fAmplitude = aAmplitude;
        }
        public Output CalcOutput(decimal aMomentInSeconds, decimal aSampleStepDuration)
        {
            return new Output(fAmplitude, null);
        }
        public IOutputable SignalOutput()
        {
            return this;
        }
    }

}
