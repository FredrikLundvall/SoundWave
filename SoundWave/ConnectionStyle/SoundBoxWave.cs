using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxWave: SoundBoxModulatedBase
    {
        public SoundBoxWave()
        {

        }
        override public double OutputValue(double aMomentInSeconds)
        {
            double valueFrequency = 0;
            foreach (var frequencyOutput in fFrequencyOutputListeners)
            {
                valueFrequency += frequencyOutput.Output(aMomentInSeconds);
            }
            double valueAmplitude = 0;
            foreach (var amplitudeOutput in fAmplitudeOutputListeners)
            {
                valueAmplitude += amplitudeOutput.Output(aMomentInSeconds);
            }
            return Math.Sin(atPhase.PhaseAsRadians) * valueAmplitude;
        }
    }
}
