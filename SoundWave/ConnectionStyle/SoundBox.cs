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
        override public double OutputValue(double aMomentInSeconds)
        {
            double valueFrequency = 0;
            foreach (var frequencyOutput in fFrequencyOutputListeners)
            {
                valueFrequency += frequencyOutput.Output(aMomentInSeconds);
            }
            double value = 0;
            foreach (var valueOutput in fValueOutputListeners)
            {
                value += valueOutput.Output(aMomentInSeconds);
            }
            double valueAmplitude = 0;
            foreach (var amplitudeOutput in fAmplitudeOutputListeners)
            {
                valueAmplitude += amplitudeOutput.Output(aMomentInSeconds);
            }
            return value * valueAmplitude;
        }
    }
}
