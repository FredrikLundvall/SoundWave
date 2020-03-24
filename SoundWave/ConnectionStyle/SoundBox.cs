using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBox: SoundBoxModulatedBase
    {
        protected readonly List<IOutputable> fValueOutputListeners = new List<IOutputable>();
        public void AddValueOutputable(IOutputable aValueOutputable)
        {
            fValueOutputListeners.Add(aValueOutputable);
        }
        override public Output OutputValue(double aMomentInSeconds)
        {
            Output valueFrequency = new Output(0, null);
            foreach (var frequencyOutput in fFrequencyOutputListeners)
            {
                valueFrequency += frequencyOutput.Output(aMomentInSeconds);
            }
            Output value = new Output(0, null);
            foreach (var valueOutput in fValueOutputListeners)
            {
                value += valueOutput.Output(aMomentInSeconds);
            }
            Output valueAmplitude = new Output(0, null);
            foreach (var amplitudeOutput in fAmplitudeOutputListeners)
            {
                valueAmplitude += amplitudeOutput.Output(aMomentInSeconds);
            }
            return (value * valueAmplitude.Amplitude) + new Output(0, valueFrequency.Phase);
        }
    }
}
