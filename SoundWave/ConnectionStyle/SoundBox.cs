using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBox: IOutputable
    {
        protected readonly List<IOutputable> fValueOutputListeners = new List<IOutputable>();
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
        public void SignalInput(IOutputable aValueOutputable)
        {
            fValueOutputListeners.Add(aValueOutputable);
        }
        virtual public Output Output(double aMomentInSeconds)
        {
            Output valueFrequency = new Output(0, null, null);
            foreach (var frequencyOutput in fFrequencyOutputListeners)
            {
                valueFrequency += frequencyOutput.Output(aMomentInSeconds);
            }
            Output value = new Output(0, null, null);
            foreach (var valueOutput in fValueOutputListeners)
            {
                value += valueOutput.Output(aMomentInSeconds);
            }
            Output valueAmplitude = new Output(0, null, null);
            foreach (var amplitudeOutput in fAmplitudeOutputListeners)
            {
                valueAmplitude += amplitudeOutput.Output(aMomentInSeconds);
            }
            return ConnectionStyle.Output.MultiplyAmplitude(value, valueAmplitude.Amplitude) + new Output(0, valueFrequency.Phase, valueFrequency.Frequency);
        }
        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
