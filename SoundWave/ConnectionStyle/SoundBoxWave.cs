using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxWave: SoundBoxModulatedBase
    {
        override public Output OutputValue(double aMomentInSeconds)
        {
            Output valueFrequency = new Output(0, null);
            foreach (var frequencyOutput in fFrequencyOutputListeners)
            {
                valueFrequency += frequencyOutput.Output(aMomentInSeconds);
            }
            Output valueAmplitude = new Output(0, null);
            foreach (var amplitudeOutput in fAmplitudeOutputListeners)
            {
                valueAmplitude += amplitudeOutput.Output(aMomentInSeconds);
            }
            return new Output(Math.Sin((valueFrequency.Phase ?? 0) * Math.PI * 2) * valueAmplitude.Amplitude, valueFrequency.Phase);
        }
    }
}
