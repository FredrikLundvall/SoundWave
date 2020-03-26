using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxWave: IOutputable
    {
        protected readonly List<IOutputable> fAmplitudeOutputListeners = new List<IOutputable>();
        protected readonly List<IOutputable> fFrequencyOutputListeners = new List<IOutputable>();
        public void AmplitudeInput(IOutputable aAmplitudeOutputable)
        {
            fAmplitudeOutputListeners.Add(aAmplitudeOutputable);
        }
        public void FrequencyInput(IOutputable aFrequencyOutputable)
        {
            fFrequencyOutputListeners.Add(aFrequencyOutputable);
        }
        public Output Output(double aMomentInSeconds)
        {
            Output valueFrequency = new Output(0, null, null);
            foreach (var frequencyOutput in fFrequencyOutputListeners)
            {
                valueFrequency += frequencyOutput.Output(aMomentInSeconds);
            }
            Output valueAmplitude = new Output(0, null, null);
            foreach (var amplitudeOutput in fAmplitudeOutputListeners)
            {
                valueAmplitude += amplitudeOutput.Output(aMomentInSeconds);
            }
            return new Output(Math.Sin((valueFrequency.Phase ?? 0) * Math.PI * 2) * valueAmplitude.Amplitude, valueFrequency.Phase, valueFrequency.Frequency);
        }
        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
